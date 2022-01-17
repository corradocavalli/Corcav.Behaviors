using System;
using System.Collections.Specialized;
using Xamarin.Forms;

namespace Corcav.Behaviors
{
    /// <summary>
    /// Manages Behavior infrastructure.
    /// </summary>
    public class Interaction
    {
        /// <summary>
        /// The property for behaviors.
        /// </summary>
        public static readonly BindableProperty BehaviorsProperty = BindableProperty.CreateAttached(
            "Behaviors",
            typeof(BehaviorCollection),
            typeof(Interaction),
            null,
            BindingMode.OneWay,
            null,
            OnBehaviorsChanged);

        /// <summary>
        /// Gets the behaviors property value on the given target.
        /// </summary>
        /// <param name="target">The target from which to get the behaviors.</param>
        /// <returns>The behaviors from the given target.</returns>
        public static BehaviorCollection GetBehaviors(BindableObject target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return (BehaviorCollection)target.GetValue(BehaviorsProperty);
        }

        /// <summary>
        /// Sets the behaviors property on the given target to the given value.
        /// </summary>
        /// <param name="target">The target on which to set a behavior value.</param>
        /// <param name="value">The value to set.</param>
        public static void SetBehaviors(BindableObject target, BehaviorCollection value)
        {
            target.SetValue(BehaviorsProperty, value);
        }

        static void OnBehaviorsChanged(BindableObject target, object oldvalue, object newvalue)
        {
            if (newvalue is not BehaviorCollection value)
            {
                return;
            }

            if (target is Element t)
            {
                t.BindingContextChanged += (s, e) =>
                {
                    var behaviors = GetBehaviors(target);

                    foreach (var behavior in behaviors)
                    {
                        if (behavior is BindableObject el)
                        {
                            el.BindingContext = target.BindingContext;
                        }
                    }
                };
            }

            value.CollectionChanged += (sender, args) =>
            {
                if (args.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (IBehavior behavior in args.NewItems)
                    {
                        behavior.Attach(target);
                    }
                }

                if (args.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (IBehavior behavior in args.OldItems)
                    {
                        behavior.Detach();
                    }
                }
            };

            foreach (var behavior in value)
            {
                behavior.Attach(target);
            }

            SetBehaviors(target, value);
        }
    }
}
