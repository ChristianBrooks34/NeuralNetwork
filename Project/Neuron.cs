public class Neuron
{
    public float[] Weights { get; private set; }
    public float B { get; private set; }
    public float Output { get; set; }

    private readonly float _initialWeightValue;

    public Neuron(int countWeights, float initialWeightValue = 0)
    {
        Weights = new float[countWeights];
        _initialWeightValue = initialWeightValue;

        Output = 0;

        InitializeWeightsToConstant();
    }

    public void Forward(Neuron[] inputNeurons)
    {
        if (Weights.Length != inputNeurons.Length)
        {
            throw new ArgumentException("Количество входов не совпадает с количеством весов.");
        }

        for (int i = 0; i < inputNeurons.Length; i++)
        {
            Output += inputNeurons[i].Output * Weights[i];
        }

        Output += B;
        Output = NeuralMath.ReLu(Output);
    }

    private void InitializeWeightsToConstant()
    {
        for (int i = 0; i < Weights.Length; i++)
        {
            Weights[i] = _initialWeightValue;
        }

        B = _initialWeightValue;
    }
}