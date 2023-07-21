﻿//HintName: MyAppMainAnyFlagEventRemovedListenerComponent.g.cs
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by
//     Entitas.Generators.ComponentGenerator.Events
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public interface IMyAppMainAnyFlagEventRemovedListener
{
    void OnAnyFlagEventRemoved(global::MyApp.Main.Entity entity);
}

public sealed class MyAppMainAnyFlagEventRemovedListenerComponent : global::Entitas.IComponent
{
    public global::System.Collections.Generic.List<IMyAppMainAnyFlagEventRemovedListener> Value;
}

public static class MyAppMainAnyFlagEventRemovedListenerEventEntityExtension
{
    public static global::MyApp.Main.Entity AddAnyFlagEventRemovedListener(this global::MyApp.Main.Entity entity, IMyAppMainAnyFlagEventRemovedListener value)
    {
        var listeners = entity.HasAnyFlagEventRemovedListener()
            ? entity.GetAnyFlagEventRemovedListener().Value
            : new global::System.Collections.Generic.List<IMyAppMainAnyFlagEventRemovedListener>();
        listeners.Add(value);
        return entity.ReplaceAnyFlagEventRemovedListener(listeners);
    }

    public static void RemoveAnyFlagEventRemovedListener(this global::MyApp.Main.Entity entity, IMyAppMainAnyFlagEventRemovedListener value, bool removeListenerWhenEmpty = true)
    {
        var listeners = entity.GetAnyFlagEventRemovedListener().Value;
        listeners.Remove(value);
        if (removeListenerWhenEmpty && listeners.Count == 0)
        {
            entity.RemoveAnyFlagEventRemovedListener();
            if (entity.IsEmpty())
                entity.Destroy();
        }
        else
        {
            entity.ReplaceAnyFlagEventRemovedListener(listeners);
        }
    }
}

public sealed class MyAppMainAnyFlagEventRemovedEventSystem : global::Entitas.ReactiveSystem<global::MyApp.Main.Entity>
{
    readonly global::Entitas.IGroup<global::MyApp.Main.Entity> _listeners;
    readonly global::System.Collections.Generic.List<global::MyApp.Main.Entity> _entityBuffer;
    readonly global::System.Collections.Generic.List<IMyAppMainAnyFlagEventRemovedListener> _listenerBuffer;

    public MyAppMainAnyFlagEventRemovedEventSystem(MyApp.MainContext context) : base(context)
    {
        _listeners = context.GetGroup(MyAppMainAnyFlagEventRemovedListenerMatcher.AnyFlagEventRemovedListener);
        _entityBuffer = new global::System.Collections.Generic.List<global::MyApp.Main.Entity>();
        _listenerBuffer = new global::System.Collections.Generic.List<IMyAppMainAnyFlagEventRemovedListener>();
    }

    protected override global::Entitas.ICollector<global::MyApp.Main.Entity> GetTrigger(global::Entitas.IContext<global::MyApp.Main.Entity> context)
    {
        return global::Entitas.CollectorContextExtension.CreateCollector(
            context, global::Entitas.TriggerOnEventMatcherExtension.Removed(MyAppMainFlagEventMatcher.FlagEvent)
        );
    }

    protected override bool Filter(global::MyApp.Main.Entity entity)
    {
        return !entity.HasFlagEvent();
    }

    protected override void Execute(global::System.Collections.Generic.List<global::MyApp.Main.Entity> entities)
    {
        foreach (var entity in entities)
        {
            foreach (var listenerEntity in _listeners.GetEntities(_entityBuffer))
            {
                _listenerBuffer.Clear();
                _listenerBuffer.AddRange(listenerEntity.GetAnyFlagEventRemovedListener().Value);
                foreach (var listener in _listenerBuffer)
                {
                    listener.OnAnyFlagEventRemoved(entity);
                }
            }
        }
    }
}