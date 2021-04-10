using System;
using System.Collections.Generic;
using UnityEngine;

// all interactable objs will use this interface
  interface IInteractable
    {
        void Interact(DisplayImage currentDisplay);
    }
