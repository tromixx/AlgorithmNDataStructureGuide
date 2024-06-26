// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;

namespace CompileCs
{
    class Problems
    {
        public void Hello()
        {
           System.Console.WriteLine("Hello");
        }
        

        
        
    }
    public sealed class Singleton
    {
        private static readonly Lazy<Singleton> instance = new Lazy<Singleton>(() => new Singleton());

        private Singleton() { }

        public static Singleton Instance
        {
            get { return instance.Value; }
        }
    }
    

    //Async Await implementation
    public class WebRequester
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<string> GetWebContentAsync(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
    }

    //Event handler
    public class Publisher
    {
        public event EventHandler<EventArgs> OnChange;

        public void RaiseEvent()
        {
            OnChange?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Subscriber
    {
        public void Subscribe(Publisher publisher)
        {
            publisher.OnChange += HandleEvent;
        }

        private void HandleEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Event received by subscriber.");
        }
    }

    //Implement a Custom IEnumerable<T> Collection
    public class CustomCollection<T> : IEnumerable<T>
    {
        private List<T> _items = new List<T>();

        public void Add(T item)
        {
            _items.Add(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    //5 Implement a Thread-Safe Blocking Queue
    public class BlockingQueue<T>
    {
        private readonly Queue<T> _queue = new Queue<T>();
        private readonly object _lock = new object();
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(0);

        public void Enqueue(T item)
        {
            lock (_lock)
            {
                _queue.Enqueue(item);
            }
            _semaphore.Release();
        }

        public T Dequeue()
        {
            _semaphore.Wait();
            lock (_lock)
            {
                return _queue.Dequeue();
            }
        }
    }

}
        //Fibonacci Sequence Assesssment
        // class Result
        // {

        //     static void Main(string[] args)
        //     {
        //         int n = Convert.ToInt32(Console.ReadLine());
        //         List<int> fibonacciSequence = fibonacci(n);

        //         foreach (int number in fibonacciSequence)
        //         {
        //             Console.WriteLine(number);
        //         }
        //     }
            
        //     public static List<int> fibonacci(int n)
        //     {
        //         List<int> fibSequence = new List<int>();

        //         if (n >= 1) fibSequence.Add(0);
        //         if (n >= 2) fibSequence.Add(1);

        //         for (int i = 2; i < n; i++)
        //         {
        //             int nextNumber = fibSequence[i - 1] + fibSequence[i - 2];
        //             fibSequence.Add(nextNumber);
        //         }

        //         return fibSequence;
        //     }

        // }
