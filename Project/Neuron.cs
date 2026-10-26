public class Neuron
{
    public float[] _weights { get; private set; }
    public float b { get; private set; }
    public float output { get; private set; }

    private readonly float _initialWeightValue;

    public Neuron(int countWeights, float initialWeightValue = 0)
    {
        _weights = new float[countWeights];
        _initialWeightValue = initialWeightValue;

        output = 0;

        InitializeWeightsToConstant();
    }

    public void Forward(Neuron[] inputNeurons)
    {
        if (_weights.Length != inputNeurons.Length)
        {
            throw new ArgumentException("Количество входов не совпадает с количеством весов.");
        }

        for (int i = 0; i < inputNeurons.Length; i++)
        {
            output += inputNeurons[i].output * _weights[i];
        }

        output += b;
        output = NeuralMath.ReLu(output);
    }

    private void InitializeWeightsToConstant()
    {
        for (int i = 0; i < _weights.Length; i++)
        {
            _weights[i] = _initialWeightValue;
        }

        b = _initialWeightValue;
    }
}