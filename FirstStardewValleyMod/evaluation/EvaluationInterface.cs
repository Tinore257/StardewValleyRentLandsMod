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
    interface EvaluationInterface
    {
        PlaceEvaluation evaluate(Generator usedGenerator);
        PlaceEvaluation evaluateAndChange(Generator usedGenerator);

        PlaceEvaluation generateAndEvaluate(Generator generator, string seed, Vector2 groesse);
    }
}
