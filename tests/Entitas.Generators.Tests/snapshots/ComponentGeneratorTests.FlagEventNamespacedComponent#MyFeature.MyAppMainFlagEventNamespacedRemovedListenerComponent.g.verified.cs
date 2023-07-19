﻿//HintName: MyFeature.MyAppMainFlagEventNamespacedRemovedListenerComponent.g.cs
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by
//     Entitas.Generators.ComponentGenerator.Events
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace MyFeature
{
public interface IMyAppMainFlagEventNamespacedRemovedListener
{
    void OnFlagEventNamespacedRemoved(global::MyApp.Main.Entity entity);
}

public sealed class MyAppMainFlagEventNamespacedRemovedListenerComponent : global::Entitas.IComponent
{
    public global::System.Collections.Generic.List<IMyAppMainFlagEventNamespacedRemovedListener> Value;
}

public static class MyAppMainFlagEventNamespacedRemovedListenerEventEntityExtension
{
    public static global::MyApp.Main.Entity AddFlagEventNamespacedRemovedListener(this global::MyApp.Main.Entity entity, IMyAppMainFlagEventNamespacedRemovedListener value)
    {
        var listeners = entity.HasFlagEventNamespacedRemovedListener()
            ? entity.GetFlagEventNamespacedRemovedListener().Value
            : new global::System.Collections.Generic.List<IMyAppMainFlagEventNamespacedRemovedListener>();
        listeners.Add(value);
        return entity.ReplaceFlagEventNamespacedRemovedListener(listeners);
    }

    public static void RemoveFlagEventNamespacedRemovedListener(this global::MyApp.Main.Entity entity, IMyAppMainFlagEventNamespacedRemovedListener value, bool removeListenerWhenEmpty = true)
    {
        var listeners = entity.GetFlagEventNamespacedRemovedListener().Value;
        listeners.Remove(value);
        if (removeListenerWhenEmpty && listeners.Count == 0)
        {
            entity.RemoveFlagEventNamespacedRemovedListener();
            if (entity.IsEmpty())
                entity.Destroy();
        }
        else
        {
            entity.ReplaceFlagEventNamespacedRemovedListener(listeners);
        }
    }
}

public sealed class MyAppMainFlagEventNamespacedRemovedEventSystem : global::Entitas.ReactiveSystem<global::MyApp.Main.Entity>
{
    readonly global::System.Collections.Generic.List<IMyAppMainFlagEventNamespacedRemovedListener> _listenerBuffer;

    public MyAppMainFlagEventNamespacedRemovedEventSystem(MyApp.MainContext context) : base(context)
    {
        _listenerBuffer = new global::System.Collections.Generic.List<IMyAppMainFlagEventNamespacedRemovedListener>();
    }

    protected override global::Entitas.ICollector<global::MyApp.Main.Entity> GetTrigger(global::Entitas.IContext<global::MyApp.Main.Entity> context)
    {
        return global::Entitas.CollectorContextExtension.CreateCollector(
            context, global::Entitas.TriggerOnEventMatcherExtension.Added(MyAppMainFlagEventNamespacedMatcher.FlagEventNamespaced)
        );
    }

    protected override bool Filter(global::MyApp.Main.Entity entity)
    {
        return !entity.HasFlagEventNamespaced() && entity.HasFlagEventNamespacedRemovedListener();
    }

    protected override void Execute(global::System.Collections.Generic.List<global::MyApp.Main.Entity> entities)
    {
        foreach (var entity in entities)
        {
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(entity.GetFlagEventNamespacedRemovedListener().Value);
            foreach (var listener in _listenerBuffer)
            {
                listener.OnFlagEventNamespacedRemoved(entity);
            }
        }
    }
}
}
