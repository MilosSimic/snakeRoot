using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LyricsCrawler.assets
{
    class Assets
    {
        public static String BASE_URL = "http://www.metrolyrics.com/{0}.html";
        public static String SEARCH_IMG_URL = "http://www.google.com";
        public static String LYRICS = "lyrics";
        public static char LINE = '-';
        public static char EMPTY = ' ';
        public static String IMAGE_XPATH = "//*[@id=\"bg-top\"]/div/img";
        public static String DIV_INTRO = "//*[@id=\"lyrics-intro\"]/div[1]/div[1]";
        public static String DIV_LYRICS = "//*[@id=\"lyrics-body-text\"]";
        public static String DIV_NAME = "//*[@id=\"lyrics-main\"]/div[1]/div[2]/header/h1";
        public static String SRC_ATTR = "src";
        public static String PLUS_INFO = "//*[@id=\"lyrics-body\"]";
        public static String P_TAG = "p";

        public static String WOLFRAM_API = "http://api.wolframalpha.com/v2/query?appid=QHY65X-92679YAEEX&input={0}&format=html,image";
    }
}
