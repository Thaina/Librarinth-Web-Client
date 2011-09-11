using System;
using System.Collections;
using System.Collections.Generic;

namespace BaseEngine
{
	static class LinkedListQueueExtension
	{
		public static bool IsLessThan<T>(this T left,T right) where T : IComparable<T>
		{
			return left.CompareTo(right) < 0;
		}
		public static bool IsGreaterThan<T>(this T left,T right) where T : IComparable<T>
		{
			return left.CompareTo(right) > 0;
		}
		public static void Enqueue<T>(this LinkedList<T> queue,ref T value) where T : IComparable<T>
		{
			var node	= queue.First;
			while(node != queue.Last && value.IsGreaterThan(node.Next.Value))
				node	= node.Next;
				
			queue.AddAfter(node,value);
		}
		public static bool Dequeue<T>(this LinkedList<T> queue,out T value)
		{
			if(queue.Count  < 1)
			{
				value	= default(T);
				return false;
			}

			value	= queue.First.Value;
			queue.RemoveFirst();
			return true;
		}
	}

	public interface IRegistered
	{
		void OnIncrease(int newSize);
		void OnDecrease(int newSize);
	}
	public class Register : IEnumerable<ushort>
	{
		IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
		public IEnumerator<ushort> GetEnumerator()
		{
			if(emptyIndex.Count < 1)
				yield break;

			var node	= emptyIndex.First;
			ushort value	= 0;
			while(value < Last)
			{
				if(!emptyIndex.Contains(value))
					yield return value;
				
				value++;
			}
		}

		readonly IRegistered callBack;
		public ushort Last { get; private set; }
		public Register(IRegistered registered)
		{
			callBack	= registered;
			Last	= 0;
		}

		readonly LinkedList<ushort> emptyIndex	= new LinkedList<ushort>();
		public ushort Alloc()
		{
			ushort index;
			if(!emptyIndex.Dequeue(out index))
			{
				index	= Last;
				Last++;

				if(callBack != null)
					callBack.OnIncrease(Last);
			}

			return index;
		}
		public void Free(ushort index)
		{
			if(index >= Last || emptyIndex.Contains(index))
				throw new ArgumentException();

			if(emptyIndex.Count > 0 || index < emptyIndex.First.Value)
				emptyIndex.Enqueue(ref index);
			else emptyIndex.AddFirst(index);
			
			if(emptyIndex.Count > Last / 2)
			{
				while(Last - 1 == emptyIndex.Last.Value)
				{
					emptyIndex.RemoveLast();
					Last--;
				}
				
				if(callBack != null)
					callBack.OnDecrease(Last);
			}
		}
	}
}