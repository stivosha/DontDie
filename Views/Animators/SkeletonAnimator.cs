using System.Collections.Generic;
using System.Drawing;
using Don_t_Die.Enums;
using Don_t_Die.Views.Animation;
using Don_t_Die.Views.Sprites;

namespace Don_t_Die.Views.Animators
{
    class SkeletonAnimator : IAnimator
    {
        public Dictionary<States, Image[]> Animation { get; set; }
        private const string BaseUrl = "Textures/Animation/Skeleton/";

        public SkeletonAnimator()
        {
            Animation = new Dictionary<States, Image[]>
            {
                [States.StandDown] = GetAnimationFromFile(BaseUrl + "Idle/Skel_idle_down.png"),
                [States.StandUp] = GetAnimationFromFile(BaseUrl + "Idle/Skel_idle_up.png"),
                [States.StandLeft] = GetAnimationFromFile(BaseUrl + "Idle/Skel_idle_left.png"),
                [States.StandRight] = GetAnimationFromFile(BaseUrl + "Idle/Skel_idle_right.png"),

                [States.MoveDown] = GetAnimationFromFile(BaseUrl + "Walk/Skel_walk_down.png"),
                [States.MoveUp] = GetAnimationFromFile(BaseUrl + "Walk/Skel_walk_up.png"),
                [States.MoveLeft] = GetAnimationFromFile(BaseUrl + "Walk/Skel_walk_left.png"),
                [States.MoveRight] = GetAnimationFromFile(BaseUrl + "Walk/Skel_walk_right.png"),

                /*[States.AttackDown] = GetAnimationFromFile(BaseUrl + "AttackBySword/Char_atk_down.png"),
                [States.AttackUp] = GetAnimationFromFile(BaseUrl + "AttackBySword/Char_atk_up.png"),
                [States.AttackLeft] = GetAnimationFromFile(BaseUrl + "AttackBySword/Char_atk_left.png"),
                [States.AttackRight] = GetAnimationFromFile(BaseUrl + "AttackBySword/Char_atk_right.png")*/
            };

            Animation[States.MoveDownLeft] = Animation[States.MoveDown];
            Animation[States.MoveDownRight] = Animation[States.MoveDown];

            Animation[States.MoveUpLeft] = Animation[States.MoveUp];
            Animation[States.MoveUpRight] = Animation[States.MoveUp];
        }

        public Image[] GetAnimationFromFile(string src)
        {
            var images = new Image[6];
            for (var i = 0; i < 6; i++)
                images[i] = SpriteSheet.CropImage(Image.FromFile(src), 16 * i, 0, 16, 16);
            return images;
        }
    }
}
