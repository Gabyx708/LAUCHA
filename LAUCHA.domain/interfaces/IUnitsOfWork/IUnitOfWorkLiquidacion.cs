﻿using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.interfaces.IUnitsOfWork
{
    public interface IUnitOfWorkLiquidacion : IDisposable
    {
        IGenericRepository<Remuneracion> RemuneracionRepository { get; }
        IGenericRepository<Retencion> RetencionRepository { get; }
        IGenericRepository<LiquidacionPersonal> LiquidacionRepository { get; }
        IGenericRepository<RemuneracionPorLiquidacionPersonal> RemuneracionLiquidacion { get; }
        IGenericRepository<RetencionPorLiquidacionPersonal> RetencionLiquidacion { get; }
        IGenericRepository<DescuentoPorLiquidacionPersonal> DescuentoLiquidacion { get; }
        int Save();
    }
}
