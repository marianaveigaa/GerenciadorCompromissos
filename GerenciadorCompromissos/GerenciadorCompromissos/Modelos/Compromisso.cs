namespace ConsoleApp.Modelos;

public class Compromisso
{
    private DateTime _data;
    public string Data
    {
        get { return _data.ToString("dd/MM/yyyy"); }
        set
        {
            _validarDataInformada(value);
            _validarDataValidaParaCompromisso();
        }
    }
    private TimeSpan _hora;
    public TimeSpan Hora 
    { 
        get => _hora;
        set
        {
            if (value < TimeSpan.Zero || value >= TimeSpan.FromHours(24))
            {
                throw new Exception($"Hora {value} inválida! Informe no formato HH:mm entre 00:00 e 23:59");
            }
            _hora = value;
        }
    }

    public string HoraFormatada => _hora.ToString(@"hh\:mm");
    public string Descricao { get; set; }
    public string Local { get; set; }

    private void _validarDataInformada(string data) {
        if (!DateTime.TryParseExact(data,
                       "dd/MM/yyyy",
                       System.Globalization.CultureInfo.GetCultureInfo("pt-BR"),
                       System.Globalization.DateTimeStyles.None,
                       out _data))
        {
            throw new Exception($"Data {data} Inválida! Use o formato dd/MM/yyyy.");
        }
    }

    private void _validarDataValidaParaCompromisso() 
    {
        if (_data<=DateTime.Now) 
        {
            throw new Exception($"Data {_data:dd/MM/yyyy} já passou.");
        }
        if (_data<=DateTime.Now.AddMinutes(15))
        {
            throw new Exception("Agende com pelo menos 15 minutos de antecedência.");
        }
    }

    public override string ToString()
    {
        return $"Compromisso: {Descricao}\n" +
               $"Data: {Data}\n" +
               $"Hora: {Hora:hh\\:mm}\n" +
               $"Local: {Local}";
    }
}