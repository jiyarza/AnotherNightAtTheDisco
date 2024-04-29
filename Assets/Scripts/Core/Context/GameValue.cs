using System;
using System.Collections.Generic;
using UnityEngine.Events;

public class GameValue<T>
{
    private T _value;
    public UnityEvent<T,T> onValueChange;

    public GameValue()
    {            
        onValueChange ??= new UnityEvent<T,T>();            
    }

    public T Value
    {
        get => _value;
        set
        {
            if (!EqualityComparer<T>.Default.Equals(value, _value))
            {
                T oldValue = _value;
                _value = value;
                onValueChange?.Invoke(oldValue, _value);
            }
        }
    }

    public bool IsNull =>_value == null; 
}
