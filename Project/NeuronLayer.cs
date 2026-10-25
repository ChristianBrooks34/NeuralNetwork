public class NeuronLayer
{
    public int CountNeurons { get; private set; }

    public Neuron[] Neurons { get; set; }

    public NeuronLayer(int countNeurons)
    {
        CountNeurons = countNeurons;
    }
}
