﻿//HintName: MyApp.Main.MyFeatureMultiplePropertiesNamespacedEntityExtension.g.cs
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by
//     Entitas.Generators.ComponentGenerator.EntityExtension
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace MyApp.Main
{
public static class MyFeatureMultiplePropertiesNamespacedEntityExtension
{
    public static bool HasMultiplePropertiesNamespaced(this Entity entity)
    {
        return entity.HasComponent(MyFeatureMultiplePropertiesNamespacedComponentIndex.Value);
    }

    public static Entity AddMultiplePropertiesNamespaced(this Entity entity, string value1, string value2, string value3)
    {
        var index = MyFeatureMultiplePropertiesNamespacedComponentIndex.Value;
        var component = (MyFeature.MultiplePropertiesNamespacedComponent)entity.CreateComponent(index, typeof(MyFeature.MultiplePropertiesNamespacedComponent));
        component.Value1 = value1;
        component.Value2 = value2;
        component.Value3 = value3;
        entity.AddComponent(index, component);
        return entity;
    }

    public static Entity ReplaceMultiplePropertiesNamespaced(this Entity entity, string value1, string value2, string value3)
    {
        var index = MyFeatureMultiplePropertiesNamespacedComponentIndex.Value;
        var component = (MyFeature.MultiplePropertiesNamespacedComponent)entity.CreateComponent(index, typeof(MyFeature.MultiplePropertiesNamespacedComponent));
        component.Value1 = value1;
        component.Value2 = value2;
        component.Value3 = value3;
        entity.ReplaceComponent(index, component);
        return entity;
    }

    public static Entity RemoveMultiplePropertiesNamespaced(this Entity entity)
    {
        entity.RemoveComponent(MyFeatureMultiplePropertiesNamespacedComponentIndex.Value);
        return entity;
    }
}
}