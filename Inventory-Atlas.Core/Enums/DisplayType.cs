using System.ComponentModel.DataAnnotations;

/// <summary>
/// Тип дисплея устройства.
/// <para/>
/// Используется для мониторов, ноутбуков, планшетов и других экранных устройств.
/// </summary>
public enum DisplayType
{
    /// <summary>
    /// Жидкокристаллический дисплей (Liquid Crystal Display). 
    /// Часто используется в бюджетных мониторах и ноутбуках.
    /// </summary>
    [Display(Name = "LCD")]
    LCD = 1,

    /// <summary>
    /// IPS (In-Plane Switching) – тип ЖК-панели с широкими углами обзора и точной цветопередачей.
    /// </summary>
    [Display(Name = "IPS")]
    IPS = 2,

    /// <summary>
    /// LED-дисплей — ЖК-дисплей с LED-подсветкой. Часто используется вместо традиционного LCD.
    /// </summary>
    [Display(Name = "LED")]
    LED = 3,

    /// <summary>
    /// OLED (Organic Light-Emitting Diode) — органические светодиоды. Высокая контрастность и насыщенные цвета.
    /// </summary>
    [Display(Name = "OLED")]
    OLED = 4,

    /// <summary>
    /// AMOLED — разновидность OLED с активной матрицей. Используется в смартфонах и планшетах.
    /// </summary>
    [Display(Name = "AMOLED")]
    AMOLED = 5,

    /// <summary>
    /// TN (Twisted Nematic) — тип ЖК-панели, бюджетный вариант, быстрый отклик, но узкие углы обзора.
    /// </summary>
    [Display(Name = "TN")]
    TN = 6,

    /// <summary>
    /// VA (Vertical Alignment) — тип ЖК-панели с высокой контрастностью, лучше углы обзора, чем TN.
    /// </summary>
    [Display(Name = "VA")]
    VA = 7,

    /// <summary>
    /// QLED — квантовые точки на LCD-матрице для улучшенной цветопередачи.
    /// </summary>
    [Display(Name = "QLED")]
    QLED = 8,

    /// <summary>
    /// MicroLED — новая технология мини-светодиодов, высокая яркость и контраст.
    /// </summary>
    [Display(Name = "MicroLED")]
    MicroLED = 9,

    /// <summary>
    /// CRT (Cathode Ray Tube) — электронно-лучевая трубка. Использовались в старых мониторах и телевизорах.
    /// </summary>
    [Display(Name = "CRT")]
    CRT = 10,

    /// <summary>
    /// Плазменный дисплей. Часто использовались в телевизорах среднего и премиум сегмента.
    /// </summary>
    [Display(Name = "Плазма")]
    Plasma = 11,

    /// <summary>
    /// EInk — электронная бумага, используется в ридерах. Минимальное энергопотребление.
    /// </summary>
    [Display(Name = "EInk")]
    EInk = 12,

    /// <summary>
    /// Другое — тип дисплея не входит в стандартные категории.
    /// </summary>
    [Display(Name = "Другое")]
    Other = 99
}
