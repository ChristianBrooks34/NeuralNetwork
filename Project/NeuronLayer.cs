public class NeuronLayer
{
    public int CountNeurons { get; private set; }

    public List<Neuron> Neurons { get; private set; }

    public NeuronLayer(int countNeurons)
    {
        CountNeurons = countNeurons;
    }

    public void Initialize(int countWeights)
    {
        Neurons = CreateNeurons(CountNeurons, countWeights);
    }

    public void Forward(Neuron[] inputNeurons)
    {
        for (int i = 0; i < CountNeurons; i++)
        {
            Neurons[i].Forward(inputNeurons);
        }
    }

    private List<Neuron> CreateNeurons(int countNeurons, int countWeights)
    {
        List<Neuron> neurons = new List<Neuron>(countNeurons);

        for (int i = 0; i < countNeurons; i++)
        {
            neurons.Add(new Neuron(countWeights));
        }

        return neurons;
    }
}
