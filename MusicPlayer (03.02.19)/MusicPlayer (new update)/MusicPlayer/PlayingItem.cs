using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class PlayingItem
    {
        public int Duration; //длина видео
        public string Name; //название видко
        public Artist Artist; // класс артист
        public Album Album; //класс альбом
        public bool? Like = null; //нравится/ненравится песня

        public void LikeItem()
        {
            Like = true;
        }

        public void DislikeItem()
        {
            Like = false;
        }
    }
}
