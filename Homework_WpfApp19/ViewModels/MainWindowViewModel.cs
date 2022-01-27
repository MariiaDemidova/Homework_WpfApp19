using Homework_WpfApp19.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Homework_WpfApp19.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
{ 
    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged([CallerMemberName] string PropertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
    }

    private double radius;
    public double Radius
    {
        get => radius;
        set
        {
            radius = value;
            OnPropertyChanged();
        }
    }
    private double length;
    public double Length
    {
        get => length;
        set
        {
            length = value;
            OnPropertyChanged();
        }
    }

    public ICommand AddCommand { get; }
    private void OnAddCommandExecute(object p)
    {
        Length = CircleCalc.Calc(Radius);
    }
    private bool CanAddCommandExecuted(object p)
    {
        if (radius > 0)
            return true;
        else
            return false;
    }
    public MainWindowViewModel()
    {
        AddCommand = new RelayCommand(OnAddCommandExecute, CanAddCommandExecuted);
    }
}
}
