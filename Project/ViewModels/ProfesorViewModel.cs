using Project.Dal;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels
{
    public class ProfesorViewModel
    {/*
        public ObservableCollection<Profesor> Profesor { get; }
        public ProfesorViewModel()
        {
            Profesor = new ObservableCollection<Profesor>(
                RepositoryFactory.GetRepository().GetProfesors()
                );

            Profesor.CollectionChanged += People_CollectionChanged;
        }

        private void People_CollectionChanged(object? sender,
            System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RepositoryFactory.GetRepository().AddProfesor(
                        Profesor[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepositoryFactory.GetRepository().DeleteProfesor(
                        e.OldItems!.OfType<Profesor>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    RepositoryFactory.GetRepository().UpdateProfesor(
                        e.NewItems!.OfType<Profesor>().ToList()[0]);
                    break;

            }
        }
        public void UpdatePerson(Profesor profesor) => Profesor[Profesor.IndexOf(profesor)] = profesor;*/
    }
}
