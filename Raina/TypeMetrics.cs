namespace Raina
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Mono.Cecil;
    using Mono.Cecil.Cil;

    public static class TypeMetrics
    {
        /// <summary>
        /// TypeRank values are computed by applying the Google PageRank
        /// algorithm on the graph of types' dependencies. A homothety of
        /// center 0.15 is applied to make it so that the average of TypeRank
        /// is 1.
        /// </summary>
        public static double TypeRank(this TypeDefinition self) => 0;

        /// <summary>
        /// The afferent coupling for a particular type is the number of types
        /// that depend directly on it.
        /// </summary>
        public static int Ca(this TypeDefinition self) => 0;

        /// <summary>
        /// The efferent coupling for a particular type is the number of types
        /// it directly depends on.
        /// </summary>
        /// <remarks>
        /// Notice that types declared in third-party assemblies are taken into 
        /// account.
        /// </remarks>
        public static int Ce(this TypeDefinition self) => 0;

        /// <summary>
        /// The single responsibility principle states that a class should not
        /// have more than one reason to change. Such a class is said to be
        /// cohesive. A high LCOM value generally  pinpoints a poorly cohesive
        /// class. There are several LCOM metrics. The LCOM takes its values
        /// in the range [0-1]. The LCOM HS (HS stands for Henderson-Sellers)
        /// takes its values in the range [0-2]. A LCOM HS value higher than
        /// 1 should be considered alarming.
        /// </summary>
        public static double LCOM(this TypeDefinition self) => 0;

        public static double LCOMHS(this TypeDefinition self) => 0;

        /// <summary>
        /// Cyclomatic complexity is a popular procedural software metric equal
        /// to the number of decisions that can be taken in a procedure.
        /// </summary>
        /// <remarks>
        /// The cyclomatic complexity metric is defined for methods. Adapted to
        /// the object oriented world, this metric is also defined for classes
        /// and structures as the sum of its methods CC. The CC of an anonymous
        /// method is not counted when computing the CC of its outer method.
        /// </remarks>
        public static int CC(this TypeDefinition self) => 0;

        /// <summary>
        /// The depth of inheritance tree for a class or structure is its
        /// number of base classes (including System.Object so DIT >= 1).
        /// </summary>
        public static int DIT(this TypeDefinition self) =>
            self.BaseType != null ? 1 + self.BaseType.Resolve().DIT() : 0;

        /// <summary>
        /// The size of instances of a class or a structure is defined as the 
        /// sum of size of instances of its fields plus the size of instances 
        /// of its base class.
        /// </summary>
        public static int SizeOfInstance(this TypeDefinition self) =>
            self.HasFields
                ? self.Fields.Sum(x => x.SizeOfInstance()) + self.BaseType.SizeOfInstance()
                : 0;

        /// <summary>
        /// The number of interfaces implemented. This metric is available for 
        /// interfaces, in this case the value is the number of interface 
        /// extended, directly or indirectly. For derived class, this metric 
        /// also count the sum of interfaces implemented by base class(es). 
        /// </summary>
        public static int NbInterfacesImplemented(this TypeDefinition self) => 0;

        /// <summary>
        /// The Association Between Classes metric for a particular class or 
        /// structure is the number of members of others types it directly 
        /// uses in the body of its methods. 
        /// </summary>
        public static int ABC(this TypeDefinition self) => 0;

        public static bool DependsOn(this TypeDefinition self, TypeDefinition other) => false;

        private static int SizeOfInstance(this TypeReference self) =>
            self.Resolve().SizeOfInstance();
    }
}
