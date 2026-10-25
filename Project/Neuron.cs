public class Neuron
{
    public float w { get; private set; }
    public float b { get; private set; }
    public float output { get; private set; }

    public void Forward(Neuron[] neurons)
    {
        for (int i = 0; i < neurons.Length; i++)
        {
            output += (neurons[i].output * neurons[i].w) + neurons[i].b;
        }
    }
}