using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildableLibrary.asset", menuName = "cry/buildableList", order = 1)]
public class BuildableLibrary : ScriptableObject, IList<Buildable>, IDictionary<string, Buildable>
{

    public BuildableLibrary aa;
    public Buildable bbb;
    public List<Buildable> buildableList;
    Dictionary<int, Buildable> buildableDictionary;



    public void OnAfterDeserialize()
    {
        if (buildableList == null)
        {
            return;
        }
        buildableDictionary = buildableList.ToDictionary(t => t.id);
    }



    public Buildable this[int index] { get { return buildableList[index]; } }

    public bool IsReadOnly
    {
        get
        {
            return ((ICollection<Buildable>)buildableList).IsReadOnly;
        }
    }

    public ICollection<string> Keys
    {
        get
        {
            return ((IDictionary<string, Buildable>)buildableDictionary).Keys;
        }
    }

    public ICollection<Buildable> Values
    {
        get
        {
            return ((IDictionary<string, Buildable>)buildableDictionary).Values;
        }
    }

    public int Count
    {
        get
        {
            return buildableList.Count;
        }
    }

    public Buildable this[string key]
    {
        get { return ((IDictionary<string, Buildable>)buildableDictionary)[key]; }
        set { ((IDictionary<string, Buildable>)buildableDictionary)[key] = value; }
    }
    Buildable IList<Buildable>.this[int index]
    {
        get
        {
            return ((IList<Buildable>)buildableList)[index];
        }

        set
        {
            ((IList<Buildable>)buildableList)[index] = value;
        }
    }

    public void Add(Buildable item)
    {
        throw new System.NotImplementedException();
    }

    public void Clear()
    {
        throw new System.NotImplementedException();
    }

    public bool Contains(Buildable item)
    {
        throw new System.NotImplementedException();
    }

    public void CopyTo(Buildable[] array, int arrayIndex)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerator<Buildable> GetEnumerator()
    {
        throw new System.NotImplementedException();
    }

    public int IndexOf(Buildable item)
    {
        throw new System.NotImplementedException();
    }

    public void Insert(int index, Buildable item)
    {
        throw new System.NotImplementedException();
    }

    public bool Remove(Buildable item)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new System.NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new System.NotImplementedException();
    }

    public void Add(string key, Buildable value)
    {
        ((IDictionary<string, Buildable>)buildableDictionary).Add(key, value);
    }

    public bool ContainsKey(string key)
    {
        return ((IDictionary<string, Buildable>)buildableDictionary).ContainsKey(key);
    }

    public bool Remove(string key)
    {
        return ((IDictionary<string, Buildable>)buildableDictionary).Remove(key);
    }

    public bool TryGetValue(string key, out Buildable value)
    {
        return ((IDictionary<string, Buildable>)buildableDictionary).TryGetValue(key, out value);
    }

    public void Add(KeyValuePair<string, Buildable> item)
    {
        ((IDictionary<string, Buildable>)buildableDictionary).Add(item);
    }

    public bool Contains(KeyValuePair<string, Buildable> item)
    {
        return ((IDictionary<string, Buildable>)buildableDictionary).Contains(item);
    }

    public void CopyTo(KeyValuePair<string, Buildable>[] array, int arrayIndex)
    {
        ((IDictionary<string, Buildable>)buildableDictionary).CopyTo(array, arrayIndex);
    }

    public bool Remove(KeyValuePair<string, Buildable> item)
    {
        return ((IDictionary<string, Buildable>)buildableDictionary).Remove(item);
    }

    IEnumerator<KeyValuePair<string, Buildable>> IEnumerable<KeyValuePair<string, Buildable>>.GetEnumerator()
    {
        return ((IDictionary<string, Buildable>)buildableDictionary).GetEnumerator();
    }
}