using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransferenciaObjetos;

namespace Ordem_servico.Models
{

    public class ManipulaDias
    {
        public static List<DateTime> PegarDias(Agendamento umAgendamento)
        {
            List<DateTime> diasSelecionados = new List<DateTime>();

            DateTime dataDe = Convert.ToDateTime(umAgendamento.DataDe);
            DateTime dataFim = Convert.ToDateTime(umAgendamento.DataFim);

            while (dataDe <= dataFim)
            {
                if (umAgendamento.Todos)
                {
                    diasSelecionados.Add(dataDe);
                }
                else
                {
                    if (umAgendamento.Domingo)
                    {
                        if (dataDe.DayOfWeek == DayOfWeek.Sunday)
                        {
                            diasSelecionados.Add(dataDe);
                        }
                    }

                    if (umAgendamento.Segunda)
                    {
                        if (dataDe.DayOfWeek == DayOfWeek.Monday)
                        {
                            diasSelecionados.Add(dataDe);
                        }
                    }

                    if (umAgendamento.Terca)
                    {
                        if (dataDe.DayOfWeek == DayOfWeek.Tuesday)
                        {
                            diasSelecionados.Add(dataDe);
                        }
                    }

                    if (umAgendamento.Quarta)
                    {
                        if (dataDe.DayOfWeek == DayOfWeek.Wednesday)
                        {
                            diasSelecionados.Add(dataDe);
                        }
                    }

                    if (umAgendamento.Quinta)
                    {
                        if (dataDe.DayOfWeek == DayOfWeek.Thursday)
                        {
                            diasSelecionados.Add(dataDe);
                        }
                    }

                    if (umAgendamento.Sexta)
                    {
                        if (dataDe.DayOfWeek == DayOfWeek.Friday)
                        {
                            diasSelecionados.Add(dataDe);
                        }
                    }

                    if (umAgendamento.Sabado)
                    {
                        if (dataDe.DayOfWeek == DayOfWeek.Saturday)
                        {
                            diasSelecionados.Add(dataDe);
                        }
                    }
                }

                dataDe = dataDe.AddDays(1);
            }

            return diasSelecionados.OrderBy(x => x).ToList();   
        }

        protected static DateTime ProximoDiaDaSemana(DateTime from, DayOfWeek dayOfWeek)
        {
            int start = (int)from.DayOfWeek;
            int target = (int)dayOfWeek;
            if (target <= start)
                target += 7;
            return from.AddDays(target - start);
        }
    }
}