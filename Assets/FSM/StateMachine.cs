using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using Object = System.Object;

public class StateMachine
{
    private IState _currentState;
    private Dictionary<System.Type, List<Transition>> transitions = new Dictionary<System.Type, List<Transition>>(0);
    private List<Transition> _currentTransitions=new List<Transition>();
    private List<Transition> _anyTransitions=new List<Transition>();
    private static List<Transition> EmptyTransitions=new List<Transition>(capacity:0);

    public void Tick()
    {

    }

    public void SetState(IState state)
    {

    }


   
    private class Transition
    {
       public Func<bool> Condition { get; }

        public IState To { get; }
    }


    public void AddTransition(IState from, IState to)//, Func<bool> predicate)
    {

    }


    private Transition GetTransition()
    {
        return null;
    }

    public void AddAnyTransition(IState state)//, Func<bool> predicate)
    {
        

    }
}
