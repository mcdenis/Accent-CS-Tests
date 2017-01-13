Namespace MyControls
    'Credit: http://stackoverflow.com/a/21020276

    ''' <summary>
    ''' Trackbar that uses doubles instead of integers.
    ''' </summary>
    Class TrackBarEx
        Inherits TrackBar
        Private m_precision As Double = 0.01

        Public Property Precision() As Double
            Get
                Return m_precision
            End Get
            Set(value As Double)
                ' todo: update the 5 properties below
                m_precision = value
            End Set
        End Property
        Public Shadows Property LargeChange() As Double
            Get
                Return MyBase.LargeChange * m_precision
            End Get
            Set(value As Double)
                MyBase.LargeChange = CInt(value / m_precision)
            End Set
        End Property
        Public Shadows Property Maximum() As Double
            Get
                Return MyBase.Maximum * m_precision
            End Get
            Set(value As Double)
                MyBase.Maximum = CInt(value / m_precision)
            End Set
        End Property
        Public Shadows Property Minimum() As Double
            Get
                Return MyBase.Minimum * m_precision
            End Get
            Set(value As Double)
                MyBase.Minimum = CInt(value / m_precision)
            End Set
        End Property
        Public Shadows Property SmallChange() As Double
            Get
                Return MyBase.SmallChange * m_precision
            End Get
            Set(value As Double)
                MyBase.SmallChange = CInt(value / m_precision)
            End Set
        End Property
        Public Shadows Property Value() As Double
            Get
                Return MyBase.Value * m_precision
            End Get
            Set(value As Double)
                MyBase.Value = CInt(value / m_precision)
            End Set
        End Property
    End Class

End Namespace