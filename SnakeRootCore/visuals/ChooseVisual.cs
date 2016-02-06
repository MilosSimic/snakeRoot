using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using snakeRootlib.visuals;

namespace SnakeRootCore.visuals
{
    public class ChooseVisual
    {
        public static snakeRootlib.visuals.Visual choose(SnakeRootCore.visuals.Visual visual)
        {
            switch(visual)
            {
                case SnakeRootCore.visuals.Visual.WaveForm:
                    return snakeRootlib.visuals.Visual.WaveForm;
                case SnakeRootCore.visuals.Visual.SpectrumLine:
                    return snakeRootlib.visuals.Visual.SpectrumLine;
                default:
                    return snakeRootlib.visuals.Visual.Spectrum;
            }
        }
    }
}
