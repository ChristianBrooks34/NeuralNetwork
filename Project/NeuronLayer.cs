using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

public class NeuronLayer
{
    public int CountNeurons { get; private set; }

    public Matrix<float> W;
    public Vector<float> B;

    public NeuronLayer(int countNeurons)
    {
        CountNeurons = countNeurons;
    }

    public void Initialize(int countWeights)
    {
        W = Matrix<float>.Build.Random(CountNeurons, countWeights, new Normal(0, Math.Sqrt(2.0 / countWeights)));
        B = Vector<float>.Build.Dense(CountNeurons);
    }

    public Vector<float> Forward(Vector<float> inputs)
    {
        return NeuralMath.ReLu((W * inputs) + B);
    }
}
