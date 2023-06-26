// Decompiled with JetBrains decompiler
// Type: Apex.MVVM.SafeObservableCollection`1
// Assembly: Apex, Version=1.4.1.0, Culture=neutral, PublicKeyToken=98d06957926c086d
// MVID: 01508FA6-931B-40FB-B83A-09DACB31E356
// Assembly location: E:\20200806\GAC Manager\GACManagerLooseBinaries\Apex.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace Apex.MVVM
{
  public class SafeObservableCollection<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, INotifyCollectionChanged
  {
    private IList<T> collection = (IList<T>) new List<T>();
    private Dispatcher dispatcher;
    private ReaderWriterLock sync = new ReaderWriterLock();

    public event NotifyCollectionChangedEventHandler CollectionChanged;

    //public SafeObservableCollection() => this.dispatcher = Application.Current.Dispatcher;

    public SafeObservableCollection()
    {
        this.collection = new List<T>();
        this.sync = new ReaderWriterLock();
        //this.dispatcher = Application.Current.Dispatcher;
        if (null == System.Windows.Application.Current)
        {
            var app = new System.Windows.Application();
            this.dispatcher = app.Dispatcher;
        }
    }


    public void Add(T item)
    {
      if (Thread.CurrentThread == this.dispatcher.Thread)
        this.DoAdd(item);
      else
      {
          Action<T> action = this.DoAdd;
          this.dispatcher.BeginInvoke(action, item);
      }
    }

    private void DoAdd(T item)
    {
      this.sync.AcquireWriterLock(-1);
      this.collection.Add(item);
      if (this.CollectionChanged != null)
        this.CollectionChanged((object) this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, (object) item));
      this.sync.ReleaseWriterLock();
    }

    public void Clear()
    {
        if (Thread.CurrentThread == this.dispatcher.Thread)
            this.DoClear();
        else
        {
            EmbossDelegate del = DoClear;
            this.dispatcher.BeginInvoke(del);
        }
    }

    private delegate void EmbossDelegate();

    private void DoClear()
    {
      this.sync.AcquireWriterLock(-1);
      this.collection.Clear();
      if (this.CollectionChanged != null)
        this.CollectionChanged((object) this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
      this.sync.ReleaseWriterLock();
    }

    public bool Contains(T item)
    {
      this.sync.AcquireReaderLock(-1);
      bool flag = this.collection.Contains(item);
      this.sync.ReleaseReaderLock();
      return flag;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
      this.sync.AcquireWriterLock(-1);
      this.collection.CopyTo(array, arrayIndex);
      this.sync.ReleaseWriterLock();
    }

    public int Count
    {
      get
      {
        this.sync.AcquireReaderLock(-1);
        int count = this.collection.Count;
        this.sync.ReleaseReaderLock();
        return count;
      }
    }

    public bool IsReadOnly => this.collection.IsReadOnly;

    public bool Remove(T item)
    {
      if (Thread.CurrentThread == this.dispatcher.Thread)
        return this.DoRemove(item);
      DispatcherOperation dispatcherOperation = this.dispatcher.BeginInvoke((Delegate) new Func<T, bool>(this.DoRemove), (object) item);
      return dispatcherOperation != null && dispatcherOperation.Result != null && (bool) dispatcherOperation.Result;
    }

    private bool DoRemove(T item)
    {
      this.sync.AcquireWriterLock(-1);
      if (this.collection.IndexOf(item) == -1)
      {
        this.sync.ReleaseWriterLock();
        return false;
      }
      bool flag = this.collection.Remove(item);
      if (flag && this.CollectionChanged != null)
        this.CollectionChanged((object) this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
      this.sync.ReleaseWriterLock();
      return flag;
    }

    public IEnumerator<T> GetEnumerator() => this.collection.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.collection.GetEnumerator();

    public int IndexOf(T item)
    {
      this.sync.AcquireReaderLock(-1);
      int num = this.collection.IndexOf(item);
      this.sync.ReleaseReaderLock();
      return num;
    }

    public void Insert(int index, T item)
    {
      if (Thread.CurrentThread == this.dispatcher.Thread)
        this.DoInsert(index, item);
      else
      {
          Action<int, T> action = DoInsert;
          this.dispatcher.BeginInvoke(action, index, item);
      }
    }

    //private delegate void BeginInvokeDelegate();

      //delegate void delegateDoInsert(int index, T item);

    private void DoInsert(int index, T item)
    {
      this.sync.AcquireWriterLock(-1);
      this.collection.Insert(index, item);
      if (this.CollectionChanged != null)
        this.CollectionChanged((object) this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, (object) item, index));
      this.sync.ReleaseWriterLock();
    }

    public void RemoveAt(int index)
    {
      if (Thread.CurrentThread == this.dispatcher.Thread)
        this.DoRemoveAt(index);
      else
      {
          Action<int> action = this.DoRemoveAt;
          this.dispatcher.BeginInvoke(action,index);
      }
    }

    private void DoRemoveAt(int index)
    {
      this.sync.AcquireWriterLock(-1);
      if (this.collection.Count == 0 || this.collection.Count <= index)
      {
        this.sync.ReleaseWriterLock();
      }
      else
      {
        this.collection.RemoveAt(index);
        if (this.CollectionChanged != null)
          this.CollectionChanged((object) this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        this.sync.ReleaseWriterLock();
      }
    }

    public T this[int index]
    {
      get
      {
        this.sync.AcquireReaderLock(-1);
        T obj = this.collection[index];
        this.sync.ReleaseReaderLock();
        return obj;
      }
      set
      {
        this.sync.AcquireWriterLock(-1);
        if (this.collection.Count == 0 || this.collection.Count <= index)
        {
          this.sync.ReleaseWriterLock();
        }
        else
        {
          this.collection[index] = value;
          this.sync.ReleaseWriterLock();
        }
      }
    }
  }
}
