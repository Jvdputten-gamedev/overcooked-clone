using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;


    public override void Interact(Player player){
        if (!HasKitchenObject()){
            if (player.HasKitchenObject()){
                player.GetKitchenObject().SetKitchenObjectParent(this);
            } else {

            }

        } else {
            // There is a kitchenobject
            if (player.HasKitchenObject()){
                //Player is carrying something
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject) ){
                    // player is holding plate
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO())){
                        GetKitchenObject().DestroySelf();
                    }
                } else {
                    // Player is not corrying plate but something else
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject)){
                        // Counter is holding a plate
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO())) {
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }

            } else {
                // player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

}
