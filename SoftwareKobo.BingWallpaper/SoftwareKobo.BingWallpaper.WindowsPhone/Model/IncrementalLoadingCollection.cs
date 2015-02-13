using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Data;

namespace SoftwareKobo.BingWallpaper.WindowsPhone.Model
{
    public class IncrementalLoadingCollection<T> : ObservableCollection<T>, ISupportIncrementalLoading, INotifyPropertyChanged
    {
        private readonly Action<IEnumerable<T>> _addItems;
        private readonly Func<IncrementalLoadingCollection<T>, bool> _hasMoreItems;
        private readonly Func<CancellationToken, int, Task<IEnumerable<T>>> _loadMoreItems;
        private bool _isLoading;

        public IncrementalLoadingCollection()
            : this(null, null, null)
        {
        }

        public IncrementalLoadingCollection(Func<CancellationToken, int, Task<IEnumerable<T>>> loadMoreItems)
            : this(loadMoreItems, null, null)
        {
        }

        public IncrementalLoadingCollection(Func<CancellationToken, int, Task<IEnumerable<T>>> loadMoreItems, Func<IncrementalLoadingCollection<T>, bool> hasMoreItems)
            : this(loadMoreItems, hasMoreItems, null)
        {
        }

        public IncrementalLoadingCollection(Func<CancellationToken, int, Task<IEnumerable<T>>> loadMoreItems, Action<IEnumerable<T>> addItems)
            : this(loadMoreItems, null, addItems)
        {
        }

        public IncrementalLoadingCollection(Func<CancellationToken, int, Task<IEnumerable<T>>> loadMoreItems, Func<IncrementalLoadingCollection<T>, bool> hasMoreItems, Action<IEnumerable<T>> addItems)
        {
            _loadMoreItems = loadMoreItems ?? LoadMoreItems;
            _hasMoreItems = hasMoreItems;
            _addItems = addItems ?? AddItems;
        }

        public event EventHandler<int> OnLoadMoreCompleted;

        public event EventHandler<int> OnLoadMoreStarted;

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                base.PropertyChanged += value;
            }
            remove
            {
                base.PropertyChanged -= value;
            }
        }

        public virtual bool HasMoreItems
        {
            get
            {
                if (_hasMoreItems == null)
                {
                    return true;
                }
                else
                {
                    return _hasMoreItems(this);
                }
            }
        }

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            protected set
            {
                _isLoading = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("IsLoading"));
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            if (IsLoading)
            {
                throw new InvalidOperationException("Only one operation in flight at a time");
            }

            IsLoading = true;

            return AsyncInfo.Run(c => LoadMoreItemsPrivateAsync(c, (int)count));
        }

        /// <summary>
        /// 定义如何将增量加载的结果追加进本集合。默认逐个追加到结尾。
        /// </summary>
        /// <param name="items">增量加载的结果。</param>
        protected virtual void AddItems(IEnumerable<T> items)
        {
            if (items != null)
            {
                foreach (var item in items)
                {
                    Add(item);
                }
            }
        }

        private async Task<LoadMoreItemsResult> LoadMoreItemsPrivateAsync(CancellationToken c, int count)
        {
            try
            {
                if (OnLoadMoreStarted != null)
                {
                    OnLoadMoreStarted(this, count);
                }

                var items = await _loadMoreItems(c, count);
                List<T> list = items == null ? null : new List<T>(items);
                int loadCount = list == null ? 0 : list.Count;

                _addItems(list);

                if (OnLoadMoreCompleted != null)
                {
                    OnLoadMoreCompleted(this, loadCount);
                }

                return new LoadMoreItemsResult()
                {
                    Count = (uint)loadCount
                };
            }
            finally
            {
                IsLoading = false;
            }
        }

        protected virtual Task<IEnumerable<T>> LoadMoreItems(CancellationToken c, int count)
        {
            return null;
        }
    }
}