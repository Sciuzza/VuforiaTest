/*
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using ES3_0Prova;

public static class EventManager_Reflection
{

    #region Delegate Types

    //public delegate void CustomDelegate();
    public delegate void CustomDelegate(object _arg1);

    public delegate void CustomDelegate<T>(T _arg1);

    #endregion

    #region Dictionaries

    
    public static Dictionary<string, CustomDelegate<object>> dict_delegateVoid_param1 = new Dictionary<string, CustomDelegate<object>>();


    #endregion

    public static void AddEvent(string _nameEvent, Type _param1)
    {

        if (dict_delegateVoid_param1.ContainsKey(_nameEvent))
        {
            Debug.LogWarning("Event already exists");
            return;
        }

        //MulticastDelegate ciccio2 = new CustomDelegate(EmptyFunction);
        

        var tArgs = new List<Type>();
        tArgs.Add(_param1);

        CustomDelegate ciccio = EmptyFunction;

        MethodInfo delGenType = ciccio.Method;

        var delDecltype = Expression.GetActionType(tArgs.ToArray());
        Delegate test = Delegate.CreateDelegate(delDecltype, delGenType);

        test = null;
        
        CustomDelegate<Bar(delDecltype)>

        dict_delegateVoid_param1.Add(_nameEvent, test);

       // Debug.Log(dict_delegateVoid_param1[_nameEvent].Method + " " + delDecltype + " " + delGenType + " " + test);

    }

    public static Type Bar(Type _t)
    {
        return _t.GetType();
    }

    public static void EmptyFunction(object _object0) { }


    public static void AddListener<T>(string _nameEvent, CustomDelegate<T> _function)
    {
        Delegate tempDelegate = null;
        

        if (dict_delegateVoid_param1.TryGetValue(_nameEvent, out tempDelegate))
        {

            Delegate[] ci = _function.GetInvocationList();

            foreach (var c in ci)
            {
                Debug.Log(c.Method.Name);
            }

            //Debug.Log(tempDelegate.Method);
            Debug.Log(_function.Method);

            tempDelegate = Delegate.Combine(tempDelegate , ci[0]); 
            

            dict_delegateVoid_param1[_nameEvent] = tempDelegate;
        }
        else
        {
            Debug.LogWarning("Event with this name has not been declared");
        }
    }
    

    public static void Invoke(string _nameEvent, object _param1)
    {
        if (dict_delegateVoid_param1.ContainsKey(_nameEvent))
        {
            dict_delegateVoid_param1[_nameEvent].DynamicInvoke(_param1); 
        }
        else
        {
            Debug.LogWarning("Event to Invoke not Found");
        }
    }

    #region Custom Dictionary
    /*
    public static List<GenericDictionary> dictionaryList = new List<GenericDictionary>();

    public class GenericDictionary
    {
        public Dictionary<string, object> _dict = new Dictionary<string, object>();

        public void Add<T>(string key, T value) where T : class
        {
            _dict.Add(key, value);
        }

        public T GetValue<T>(string key) where T : class
        {
            return _dict[key] as T;
        }
    }

    // To improve
    public static void AddListener<A, B>(string _nameEvent, CustomDelegate<A, B> _customDelegate)
    {
        GenericDictionary newDictionary = dictionaryList.Find(x => x._dict.ContainsKey(_nameEvent));

        // Check dictionary list if it already exists and evaluate exit function 
        if (newDictionary != null)
        {
            newDictionary.Add(_nameEvent, _customDelegate);
            return;
        }

        newDictionary = new GenericDictionary();

        // Use Add<T> generic function to add a new CustomDelegate to created dictionary
        newDictionary.Add(_nameEvent, _customDelegate);

        // Add new dictionary to dictionary list
        dictionaryList.Add(newDictionary);

        Debug.Log("Listener added\n");
    }
    
    #endregion
}
*/