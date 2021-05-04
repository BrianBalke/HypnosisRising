using HypnosisRising.CaseWork.Roles;
using HypnosisRising.MVVMExtensions.Navigation;
using HypnosisRising.RoleAssigner.ViewModels;
using HypnosisRising.RoleAssigner.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace HypnosisRising.RoleAssigner
{
    /// <summary>
    /// Module that registers the ability to configure records from the
    /// <see cref="HypnosisRising.CaseWork.Roles"/> module:
    /// <list type="bullet">
    /// <item><see cref="Person"/></item>
    /// <item><see cref="Contact"/></item>
    /// <item><see cref="Client"/></item>
    /// <item><see cref="Therapist"/></item>
    /// </list>
    /// </summary>
    public class RoleModule : 
        IModule,
        IModelConfiguration<Person>,
        IModelConfiguration<Contact>,
        IModelConfiguration<Client>,
        IModelConfiguration<Therapist>
    {
        string IModelConfiguration<Person>.Uri => 
            "HyposisRising.RoleAssigner.Views.PersonForm";
        string IModelConfiguration<Contact>.Uri => 
            "HyposisRising.RoleAssigner.Views.ContactForm";
        string IModelConfiguration<Client>.Uri => 
            "HyposisRising.RoleAssigner.Views.ClientForm";
        string IModelConfiguration<Therapist>.Uri => 
            "HyposisRising.RoleAssigner.Views.TherapistForm";

        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry p_container)
        {
            p_container.RegisterInstance<IModelConfiguration<Person>>(this);
            p_container.RegisterInstance<IModelConfiguration<Contact>>(this);
            p_container.RegisterInstance<IModelConfiguration<Client>>(this);
            p_container.RegisterInstance<IModelConfiguration<Therapist>>(this);

            p_container.RegisterForNavigation<PersonForm, PersonFormViewModel>(
                            (this as IModelConfiguration<Person>).Uri );
            p_container.RegisterForNavigation<ContactForm, ContactFormViewModel>(
                            (this as IModelConfiguration<Contact>).Uri);
            p_container.RegisterForNavigation<ClientForm, ClientFormViewModel>(
                            (this as IModelConfiguration<Client>).Uri);
            p_container.RegisterForNavigation<TherapistForm, TherapistFormViewModel>(
                            (this as IModelConfiguration<Therapist>).Uri);
        }
    }
}