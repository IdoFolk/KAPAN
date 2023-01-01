using System.Media;
namespace KapanGame
{
    class Sounds
    {
        public SoundPlayer BackgroundMusic { get; set; } 
        public SoundPlayer WinSFX { get; set; } 
        public SoundPlayer DieSFX { get; set; } 
        public Sounds()
        {
            if(OperatingSystem.IsWindows())
            {
                BackgroundMusic = new SoundPlayer("Background_Music.wav");
                WinSFX = new SoundPlayer("Win_SFX.wav");
                DieSFX = new SoundPlayer("Die_SFX.wav");
            }

        }
        public void Load()
        {
            BackgroundMusic.Load();
            WinSFX.Load();
            DieSFX.Load();

        }

    }
}
