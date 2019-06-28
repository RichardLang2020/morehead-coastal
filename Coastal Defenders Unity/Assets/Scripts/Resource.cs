using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour {

    private int currentCount;
    private int maxCount;
    private int cost;
    private string resourceName;

    public Resource(string resourceName, int cost, int maxCount) {
        this.resourceName = resourceName;
        this.cost = cost;
        this.maxCount = maxCount;
        this.currentCount = 0;
    }

    /* Getter Methods */
    public string getName() {
        return this.resourceName;
    }
    public int getCount() {
        return this.currentCount;
    }
    public int getMaxCount() {
        return this.maxCount;
    }
    public int getCost() {
        return this.cost;
    }

    /*
     * CanIncrease() gives the program an idea on whether or not this resource can still be further increased.
     * Input:   currentMoney - Current amount of money remaining for the player
     * Output:  Boolean representing whether or not more of the resource can be purchased
     */
    public bool CanIncrease(int currentMoney) {
        if(this.currentCount == this.maxCount || this.cost > currentMoney) {
            return false;
        } else {
            return true;
        }
    }
    /* 
     * CanDecrease() gives the program an idea on whether or not this resource can still be decreased.
     * Input:   N/A
     * Output:  Boolean representing whether or not more of the resource can be purchased
     */
    public bool CanDecrease() {
        if(this.currentCount == 0) {
            return false;
        } else {
            return true;
        }
    }

    /*
     * BuyResource() tells the program to purchase one unit of the resource given a certain amount of money.
     * Input:   currentMoney - Current amount of money remaining for the player
     * Output:  Integer representing how much money is remaining after the purchase
     */
    public int BuyResource(int currentMoney) {
        if(!CanIncrease(currentMoney)) {
            throw new System.InvalidOperationException("User cannot perform this operation!");
        }

        this.currentCount++;
        return currentMoney - this.cost;
    }
    /*
     * SellResource() tells the program to sell one unit of the resource given a certain amount of money.
     * Input:   currentMoney - Current amount of money remaining for the player
     * Output:  Integer representing how much money is remaining after the sale
     */
    public int SellResource(int currentMoney) {
        if (!CanDecrease()) {
            throw new System.InvalidOperationException("User cannot perform this operation!");
        }

        this.currentCount--;
        return currentMoney + this.cost;
    }
}
