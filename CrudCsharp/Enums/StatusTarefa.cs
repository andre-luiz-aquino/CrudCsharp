﻿using System.ComponentModel;

namespace CrudCsharp.Enums
{
    public enum StatusTarefa
    {
        [Description("A fazer")]
        Afazer = 1,
        [Description("Em andamento")]
        EmAndamento = 2,
        [Description("Concluido")]
        Concluido = 3
    }
}
