namespace JumpOnAHeadGame.Controller.Managers
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework.Audio;

    public static class SoundManager
    {
        private static Dictionary<string, SoundEffect> effects = new Dictionary<string, SoundEffect>();
        private static Dictionary<string, SoundEffectInstance> helper = new Dictionary<string, SoundEffectInstance>();
     
        public static void Add(string name, SoundEffect effect)
        {
            effects.Add(name, effect);
        }
  
        public static void LoadContent()
        {
            SoundEffect menuSound = Globals.Content.Load<SoundEffect>("MenuSound");
            SoundEffect sound1 = Globals.Content.Load<SoundEffect>("Sound1");
            SoundEffect sound2 = Globals.Content.Load<SoundEffect>("Sound2");
            SoundEffect sound3 = Globals.Content.Load<SoundEffect>("Sound3");
            SoundEffect sound4 = Globals.Content.Load<SoundEffect>("Sound4");
            SoundEffect sound5 = Globals.Content.Load<SoundEffect>("Sound5");
            SoundEffect sound6 = Globals.Content.Load<SoundEffect>("Sound6");
            SoundEffect snowballHit = Globals.Content.Load<SoundEffect>("SnowImpactOnBlock");
            SoundEffect snowballHitBlock = Globals.Content.Load<SoundEffect>("SnowballHit");
            SoundEffect menuMoveSound = Globals.Content.Load<SoundEffect>("MenuMoveSound");
            SoundEffect errorSound = Globals.Content.Load<SoundEffect>("ErrorSound");
            SoundEffect healthPickUp = Globals.Content.Load<SoundEffect>("HealthPackSound");
            Add("MenuSound", menuSound);
            Add("Sound1", sound1);
            Add("Sound2", sound2);
            Add("Sound3", sound3);
            Add("Sound4", sound4);
            Add("Sound5", sound5);
            Add("Sound6", sound6);
            Add("SnowballHit", snowballHit);
            Add("SnowballHitBlock", snowballHitBlock);
            Add("MenuMove", menuMoveSound);
            Add("ErrorSound", errorSound);
            Add("HealthPack", healthPickUp);
        }

        public static void Play(string name)
        {
            if (!helper.ContainsKey(name))
            {
                SoundManager.AddToHelper(name, effects[name].CreateInstance());
            }

            helper[name].Volume = 0.2f;
            helper[name].Play();
        }

        public static void Play(string name, float volume)
        {
            if (!helper.ContainsKey(name))
            {
                SoundManager.AddToHelper(name, effects[name].CreateInstance());
            }

            helper[name].Volume = volume;
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

        public static SoundState GetState(string name)
        {
            if (helper[name].State == SoundState.Playing)
            {
                return SoundState.Playing;
            }
            else if (helper[name].State == SoundState.Stopped)
            {
                return SoundState.Stopped;
            }
            else
            {
                return SoundState.Paused;
            }
        }

        private static void AddToHelper(string name, SoundEffectInstance effect)
        {
            helper.Add(name, effect);
        }
    }
}
