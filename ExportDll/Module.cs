using System;
using System.IO;
using System.Collections.Generic;

namespace BaseEngine
{
	public struct ID
	{
		public readonly bool IsCreated;
		internal readonly ushort ModuleIndex;
		public readonly ushort Index;
		internal ID(ushort moduleIndex,ushort dataIndex)
		{
			ModuleIndex	= moduleIndex;
			Index	= dataIndex;
			IsCreated	= true;
		}
	}

	public class Locker<T> : IRegistered
	{
		T[] data	= new T[4];
		public T[] Data { get { return data; } }
		protected readonly Register register;
		public Locker()
		{
			register	= new Register(this);
			OnResize(data.Length);
		}

		protected virtual void OnResize(int newSize) { }
		void IRegistered.OnIncrease(int newSize)
		{
			if(newSize > data.Length)
			{
				Array.Resize(ref data,data.Length * 2);
				OnResize(data.Length);
			}
		}
		void IRegistered.OnDecrease(int newSize)
		{
			if(newSize < data.Length / 2)
			{
				Array.Resize(ref data,newSize);
				OnResize(data.Length);
			}
		}
	}
	
	public class ModuleFactory<T> : Locker<Module<T>>
	{
		public Module<T> this[string name]
		{
			get
			{
				ushort index;
				if(!indexID.TryGetValue(name,out index))
					return null;

				return Data[index];
			}
			set
			{
				if(value != null)
				{
					ushort index;
					Get(name,out index);
					Data[index]	= value;
				}
				else Free(name);
			}
		}

		readonly Dictionary<string,ushort> indexID	= new Dictionary<string,ushort>();
		public void Get(string name,out ushort index)
		{
			if(!indexID.TryGetValue(name,out index))
			{
				index	= register.Alloc();
				indexID.Add(name,index);
			}
		}
		public void Free(string name)
		{
			ushort index;
			if(indexID.TryGetValue(name,out index))
				register.Free(index);
		}
	}

	public static class ModuleAttributeExtension
	{
		public static A[] GetCustomAttributes<A>(this Type type) where A : Attribute
		{
			return type.GetCustomAttributes(typeof(A),false) as A[];
		}
	}

	[AttributeUsage(AttributeTargets.Class,AllowMultiple = false,Inherited = false)]
	public class ModuleNameAttribute : Attribute
	{
		public readonly string Name;
		public ModuleNameAttribute(string name) { Name	= name; }
	}
	public abstract class Module<T> : Locker<T>
	{
		static readonly ModuleFactory<T> modules	= new ModuleFactory<T>();
		public static void Add<M>() where M : Module<T>,new()
		{
			var module	= new M();
			modules[module.Name]	= module;
		}
		public static M Get<M>(ID id) where M : Module<T>
		{
			return Get(id) as M;
		}
		public static Module<T> Get(ID id)
		{
			if(!id.IsCreated)
				throw new ArgumentException();

			return modules.Data[id.ModuleIndex];
		}
		public static Module<T> Get(string name)
		{
			return modules[name];
		}
		
		public readonly ushort ModuleIndex;
		public readonly string Name;
		public Module()
		{
			Name	= this.GetType().GetCustomAttributes<ModuleNameAttribute>()[0].Name;
			modules.Get(Name,out ModuleIndex);
		}

		public void Alloc(out ID id)
		{
			id	= new ID(ModuleIndex,register.Alloc());
			if(!id.IsCreated)
				throw new ArgumentException();

			OnAlloc(id.Index);
		}
		public void Load(ID id,BinaryReader reader)
		{
			if(!id.IsCreated)
				throw new ArgumentException();

			OnLoad(id.Index,reader);
		}
		public void Save(ID id,BinaryWriter writer)
		{
			if(!id.IsCreated)
				throw new ArgumentException();

			OnSave(id.Index,writer);
		}
		public void Free(ref ID id)
		{
			if(!id.IsCreated)
				throw new ArgumentException();

			OnFree(id.Index);
			register.Free(id.Index);
			id	= default(ID);
		}
		
		protected abstract void OnAlloc(ushort index);
		protected abstract void OnLoad(ushort index,BinaryReader reader);
		protected abstract void OnSave(ushort index,BinaryWriter writer);
		protected abstract void OnFree(ushort index);
	}
}