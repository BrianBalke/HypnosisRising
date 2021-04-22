# HypnosisRising

The Hypnosis Rising Case Recorder is a tool for capturing the goals and outcomes of a hypnotherapy case.

<h2>Principles of Hypnotherapy</h2>

As promoted by Carl Jung and demonstrated so wonderfully by Milton Erickson, therapy must meet the client where they are. Terms, goals, and methods must be familiar and comfortable. Of course, as therapy entrains personal growth, those three elements evolve over time.

Hypnotherapy has historically been seen as a method for suppressing uncomfortable behaviors. Many therapists will record trance work for reinforcement between sessions. The limitation of this practice is that encountered by Freud. The subconscious mind (managing our well-being) depends upon the conscious mind for direction. If the client does not <em>understand</em> why specific changes are beneficial, ultimately the subconscious will discount the authority of the therapist, with subsequent recidivism.

While the therapist's session notes often contain that rationale, they also include honest assessments of client behavior that should be held in reserve.

<h2>Trance Process</h2>

The power of hypnotherapy is found in the trance state. Trance is a natural state, often arising in pleasurable circumstances (at a movie theater or with a romantic partner). When in trance, the entire mind processes experience. Challenges often arise in crisis, when the mind discovers new methods for securing survival. Those methods, tapping into powerful primitive resources, may be pushed forward in situations that generate <em>similar</em> emotions, with personally and socially undesirable consequences.

A well-trained hypnotherapist recognizes the imbalances in the client's behavior pattern and applies specific methods to restore balance. Regarding the Kappasinian school of therapy, a mature description can be found in <a href="https://hypnosisrising.com/2020/06/04/foundations-and-practice/">The Foundations and Practice of Lay Hypnotherapy</a>. A recording application is an ideal place to organize those elements before trance is induced, not least because the plan can be linked to prompts and scripts.

<h2>Technology</h2>

At the heart of any fully functional GUI is an independent domain model. Too many GUI frameworks were designed to support transaction record-keeping. Microsoft, through its Patterns and Practices team, finally made a complete break with this model, which was characterized as a "Model-View-Viem Model" design pattern. The supporting framework, PRISM, was spun off as the PRISM open-source project. These two elements - the domain model and PRISM MVVM - are the foundation of the Case Recorder project.

The domain model comes first in the development, and that focus revealed that PRISM required expansion to support a fully model-driven development strategy. Extensions to the framework will be implemented to allow the application to control the organization of the command surface, rather than ceding that responsibility to modules. This concern also applies to validation, which in current practice requires all constraints to be pushed up to the user interface, rather than remaining encapsulated in the domain or persistence layer. These extensions are captured in the MVVMExtensions portion of the solution.

Design and development will proceed incrementally. The Case Recorder document in the project root captures the vision, feature set, and design analysis. This will be extended with each phase, while the GitHub project mechanism will be used to track requirements.
