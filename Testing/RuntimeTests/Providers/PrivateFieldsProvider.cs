﻿using System.Collections.Generic;
using UnityEngine;

public class PrivateHolder {
    public PrivateHolder() { }

    public void Setup() {
        SerializedField = 1;
        SerializedProperty = 2;
    }

    [SerializeField]
    private int SerializedField;

    [SerializeField]
    private int SerializedProperty { get; set; }

    public override bool Equals(object obj) {
        var other = obj as PrivateHolder;
        if (other == null) return false;

        return
            SerializedField == other.SerializedField &&
            SerializedProperty == other.SerializedProperty;
    }

    public override int GetHashCode() {
        return SerializedField.GetHashCode() + (17 * SerializedProperty.GetHashCode());
    }
}

public class PrivateFieldsProvider : TestProvider<PrivateHolder> {
    public override bool Compare(PrivateHolder before, PrivateHolder after) {
        return before.Equals(after);
    }

    public override IEnumerable<PrivateHolder> GetValues() {
        var holder = new PrivateHolder();
        holder.Setup();
        yield return holder;
    }
}
