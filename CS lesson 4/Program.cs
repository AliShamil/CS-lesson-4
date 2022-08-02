using System;

namespace CS_lesson_4;


struct Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X=x;
        Y=y;
    }

    public override string ToString()
    {
        return @$"X -> {X} 
Y -> {Y}";
    }
}



class Counter
{
    private int _max;
    private int _min;
    private int _currentValue;

    public int Min
    {
        get { return _min; }
        set
        {
            if (value > _max)
            {
                _min = 0;
                _max = 100;
                _currentValue = _min;
            }

            else
                _min = value;

        }
    }



    public int Max
    {
        get { return _max; }
        set
        {
            if (value < _min)
            {
                _min = 0;
                _max = 100;
                _currentValue = _min;
            }

            else
                _max = value;

        }
    }




    public Counter()
    {
        _min = 0;
        _max = 100;
        _currentValue = _min;
    }


    public Counter(int min, int max)
    {
        _min=min;
        _max=max;
        _currentValue=_min;
    }


    public void increment()
    {
        if (_currentValue == _max)
            _currentValue = _min;

        else
            ++_currentValue;
    }


    public void decrement()
    {
        if (_currentValue == _min)
            _currentValue = _max;
        else
            --_currentValue;
    }


    public int getCurrent() { return _currentValue; }

    public override string ToString()
    {
        return $"Current value: {getCurrent()}";
    }

}



class Fraction
{
    public int Numerator { get; set; }
    private int _denominator;


    public int Denominator
    {
        get { return _denominator; }
        set {
            if (value != 0)
                _denominator = value;
            else
                throw new Exception("Enter denominator different from zero");
        }
    }

    public Fraction()
    {
        Numerator = 0;
        _denominator = 1;
    }

    public Fraction(int numerator, int denominator)
    {
        Numerator=numerator;
        if (denominator != 0)
            _denominator = denominator;
        else
            throw new Exception("Enter denominator different from zero");
       
    }





    int EKOB(int n1, int n2)
    {
        int ekob;

        ekob = (n1 > n2) ? n1 : n2;

        do
        {
            if (ekob % n1 == 0 && ekob % n2 == 0)
                return ekob;

            else
                ++ekob;

        } while (true);


    }

    int EBOB(int n1, int n2)
    {
        while (n1 != n2)
        {
            if (n1 > n2)
                n1 -= n2;
            else
                n2 -= n1;
        }
        return n1;
    }




    public Fraction Multiply(ref Fraction other)
    {
        Fraction newFrac = new Fraction();
        newFrac.Numerator = Numerator * other.Numerator;
        newFrac._denominator = _denominator * other._denominator;
        return newFrac;
    }

    public Fraction Add(ref Fraction other)
    {
        Fraction newFrac = new Fraction();
        int newDenominator = EKOB(_denominator, other._denominator);
        newFrac._denominator = newDenominator;
        newFrac.Numerator = (Numerator * (newDenominator / _denominator)) + (other.Numerator * (newDenominator / other._denominator));
        return newFrac;
    }

    public Fraction Minus(ref Fraction other)
    {
        Fraction newFrac = new Fraction();
        int newDenominator = EKOB(_denominator, other._denominator);
        newFrac._denominator = newDenominator;
        newFrac.Numerator = (Numerator * (newDenominator / _denominator)) - (other.Numerator * (newDenominator / other._denominator));
        return newFrac;
    }

    public Fraction Divide(ref Fraction other)
    {
        Fraction newFrac = new Fraction();
        newFrac.Numerator = Numerator * other._denominator;
        newFrac._denominator = _denominator * other.Numerator;
        return newFrac;
    }

    public void Simplify()
    {
            int ebob = EBOB(Numerator, _denominator);
            Numerator /= ebob;
            _denominator /= ebob;
    }

    public override string ToString()
    {
        if(Numerator!= 0 && _denominator == 1)
            return $"Result: {Numerator}";

        return $"Result: {Numerator} / {_denominator}";
    }

}



internal partial class Program
{

    
    static void Main()
    {



        #region Point

        //Point point = new Point(1, 2);
        //Point point = new();

        //Console.WriteLine(point);

        //point.X = 4;
        //Console.WriteLine(point);

        #endregion



        #region Counter

        //Counter c1 = new Counter(1, 200);
        //Counter c1 = new();
        //c1.decrement();
        ////c1.increment();
        ////c1.increment();
        ////c1.increment();
        //Console.WriteLine(c1);

        #endregion



        #region Fraction

        //Fraction f1 = new Fraction(15,15);
        //Fraction f2 = new Fraction(10,5);
        //Fraction result;

        //result = f1.Add(ref f2);
        //result = f1.Minus(ref f2);
        //result = f1.Divide(ref f2);
        //result = f1.Multiply(ref f2);
        //result.Simplify();

        //Console.WriteLine(result); 

        #endregion



    }
}
