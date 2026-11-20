using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Reflection.Emit;

public class NeuralNetwork
{
    private readonly NeuronLayer[] _layers;
    private readonly Vector<float> _inputVector;
    private readonly float _learningRate;

    public NeuralNetwork(int inputCount, float learningRate, params NeuronLayer[] layers)
    {
        if (inputCount <= 0)
            throw new ArgumentException("Количество входов должно быть больше нуля.");

        if (layers == null || layers.Length == 0)
            throw new ArgumentException("Сеть должна содержать хотя бы один слой.");

        _layers = layers;
        _learningRate = learningRate;
        _inputVector = Vector<float>.Build.Dense(inputCount);

        int previousLayerSize = inputCount;
        for (int i = 0; i < _layers.Length; i++)
        {
            _layers[i].Initialize(previousLayerSize);
            previousLayerSize = _layers[i].CountNeurons;
        }
    }

    public Vector<float> Predict(float[] inputs)
    {
        if (inputs == null || inputs.Length != _inputVector.Count)
            throw new ArgumentException($"Ожидалось входов: {_inputVector.Count}, получено: {inputs?.Length ?? 0}.");

        for (int i = 0; i < inputs.Length; i++)
        {
            _inputVector[i] = inputs[i];
        }

        Vector<float> currentSignal = _inputVector;
        for (int i = 0; i < _layers.Length; i++)
        {
            currentSignal = _layers[i].Forward(currentSignal);
        }

        return currentSignal;
    }

    public void Train(float[] inputs, float[] targets, float learningRate)
    {
        
    }

    public void TrainLinearModel(int a, int B, float lr, int n, int yTrue)
    {
        float b = 1;
        float w1 = 1;
        float w2 = 1;

        for (int i = 0; i < n; i++)
        {
            //w1 = y
            //y = e
            //e = L

            var y = w1 * a + w2 * B + b;

            var e = y - yTrue;

            var L = e * e;

            var dL_de = 2 * e;
            var de_dy = 1;
            var dy_dw1 = a;

            var dL_dw1 = dL_de * de_dy * dy_dw1;

            var dy_dw2 = B;

            var dL_dw2 = dL_de * de_dy * dy_dw2;

            var dy_db = 1;

            var dL_db = dL_de * de_dy * dy_db;

            w1 -= lr * dL_dw1;
            w2 -= lr * dL_dw2;
            b -= lr * dL_db;
        }

        Console.WriteLine($"yTrue = {yTrue}; w1 = {w1}; w2 = {w2}; b = {b}; y = {Math.Round(w1 * a + w2 * B + b, 4)}");
    }

    public void TrainSecondModel(bool a, bool b, float lr, int yTrue)
    {
        
    }
}
