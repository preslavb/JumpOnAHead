namespace JumpOnAHeadGame.Controller.Managers
{
    using Microsoft.Xna.Framework.Audio;
    using System.Collections.Generic;

    public static class SoundManager
    {
        private static Dictionary<string, SoundEffect> effects = new Dictionary<string, SoundEffect>();
        private static Dictionary<string, SoundEffectInstance> helper = new Dictionary<string, SoundEffectInstance>();

        public static void Add(string name, SoundEffect effect)
        {
            effects.Add(name, effect);
        }

        public static void Play(string name)
        {
            if (!helper.ContainsKey(name))
            {
                SoundManager.AddToHelper(name, effects[name].CreateInstance());
            }
            helper[name].Play();
        }

        public static void Stop(string name)
        {
            if (!helper.ContainsKey(name))
            {
                SoundManager.AddToHelper(name, effects[name].CreateInstance());
            }
            helper[name].Stop();
        }

        public static void Pause(string name)
        {
            if (!helper.ContainsKey(name))
            {
                SoundManager.AddToHelper(name, effects[name].CreateInstance());
            }
            helper[name].Pause();
        }

        public static void Resume(string name)
        {
            if (!helper.ContainsKey(name))
            {
                SoundManager.AddToHelper(name, effects[name].CreateInstance());
            }
            helper[name].Resume();
        }

        private static void AddToHelper(string name, SoundEffectInstance effect)
        {
            helper.Add(name, effect);
        }
    }
}
