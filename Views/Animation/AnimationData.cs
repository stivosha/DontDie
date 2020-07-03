using System.Collections.Generic;
using Don_t_Die.Enums;
using Don_t_Die.Views.Animators;

namespace Don_t_Die.Views.Animation
{
    public static class AnimationData
    {
        public static Dictionary<GameObjectsId, IAnimator> Animations = new Dictionary<GameObjectsId, IAnimator>
        {
            [GameObjectsId.Player] = new PlayerAnimator(),
            [GameObjectsId.Skeleton] = new SkeletonAnimator()
        };
    }
}
