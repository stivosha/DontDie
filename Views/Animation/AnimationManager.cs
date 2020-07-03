using System.Collections.Generic;
using System.Drawing;
using Don_t_Die.Enums;
using Don_t_Die.Models.GameObjects;
using Don_t_Die.Views.Sprites;

namespace Don_t_Die.Views.Animation
{
    static class AnimationManager
    {
        public static List<Sprite> CalcCurrentSprites(List<IEntity> entities, int currentFrame)
        {
            var sprites = new List<Sprite>();
            foreach (var entity in entities)
                switch (entity.Id)
                {
                    case GameObjectsId.Player:
                        var arrayOfAnimations = AnimationData.Animations[GameObjectsId.Player].Animation[entity.State];
                        sprites.Add(new Sprite{
                            X = entity.Collider.X,
                            Y = entity.Collider.Y,
                            Image = arrayOfAnimations[currentFrame % arrayOfAnimations.Length]
                        });
                        break;
                    case GameObjectsId.Cow:
                        sprites.Add(new Sprite
                        {
                            X = entity.Collider.X,
                            Y = entity.Collider.Y,
                            Image = Image.FromFile("Textures/Animals/cow.png")
                        });
                        break;
                    case GameObjectsId.Skeleton:
                        var arrayOfAnimation = AnimationData.Animations[GameObjectsId.Skeleton].Animation[entity.State];
                        sprites.Add(new Sprite
                        {
                            X = entity.Collider.X,
                            Y = entity.Collider.Y,
                            Image = arrayOfAnimation[currentFrame % arrayOfAnimation.Length]
                        });
                        break;
                }
            return sprites;
        }
    }
}
