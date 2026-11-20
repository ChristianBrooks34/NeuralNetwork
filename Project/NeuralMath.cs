using System.Net.NetworkInformation;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

public static class NeuralMath
{
    public static Vector<float> ReLu(Vector<float> values)
    {
        return values.Map(v => v > 0 ? v : 0f);
    }

    public static Vector<float> EvaluateLoss(Vector<float> trueValue, Vector<float> output)
    {
        return trueValue - output;
    }
}
