using FirstStardewValleyMod.datastructs;
using FirstStardewValleyMod.locationGenerators;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStardewValleyMod.evaluation
{
    class DefaultEvaluation : EvaluationInterface
    {
        public PlaceEvaluation evaluate(Generator usedGenerator)
        {
            throw new NotImplementedException();
        }

        public PlaceEvaluation evaluateAndChange(Generator usedGenerator)
        {
            throw new NotImplementedException();
        }

        public PlaceEvaluation generateAndEvaluate(Generator generator,string seed, Vector2 groesse)
        {
            generator.generate(seed, groesse);
            return evaluate(generator);
        }
    }
}
