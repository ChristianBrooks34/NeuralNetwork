using System.ComponentModel.DataAnnotations;
using System;
using System.Diagnostics;

public class NeuralNetwork
{
    public NeuralNetwork(int inputNeuron, int outputNeuron, NeuronLayer[] neuronLayers)
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
