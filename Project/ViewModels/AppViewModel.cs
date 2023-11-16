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
    public class AppViewModel
    {
        public ObservableCollection<Student> Studenti { get; }
        public ObservableCollection<Kolegij> Kolegiji { get; }
        public AppViewModel()
        {
            Studenti = new ObservableCollection<Student>(
                RepositoryFactory.GetRepository().GetStudents()
                );
            Kolegiji = new ObservableCollection<Kolegij>(RepositoryFactory.GetRepository().GetKolegiji());
            Studenti.CollectionChanged += People_CollectionChanged;
            Kolegiji.CollectionChanged += Kolegiji_CollectionChanged;
        }

        private void Kolegiji_CollectionChanged(object? sender, 
            System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RepositoryFactory.GetRepository().AddKolegij(
                        Kolegiji[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepositoryFactory.GetRepository().DeleteKolegij(
                        e.OldItems!.OfType<Kolegij>().ToList()[0]);
                    break;
            }
        }

        private void People_CollectionChanged(object? sender,
            System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RepositoryFactory.GetRepository().AddStudent(
                        Studenti[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepositoryFactory.GetRepository().DeleteStudent(
                        e.OldItems!.OfType<Student>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    RepositoryFactory.GetRepository().UpdateStudent(
                        e.NewItems!.OfType<Student>().ToList()[0]);
                    break;
            }
        }
        public void UpdatePerson(Student student) => Studenti[Studenti.IndexOf(student)] = student;
    }
}
