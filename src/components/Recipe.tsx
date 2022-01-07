import * as React from "react";
import { Recipe } from "src/store/Recipe";
import "./Recipe.css";

interface Props{
    recipe: Recipe
    deleteRecipe: Function
}

const RecipeComponent = (prop: Props) => {
    return (
        <div className="card p-2 mb-2">
            <div className="top-row">
                <h1 className="title">{prop.recipe.title}</h1>
                <button className="btn-edit btn btn-sm btn-danger" onClick={() => prop.deleteRecipe()}>Delete </button>
            </div>
            <p className="">{prop.recipe.description}</p>
        </div>
    );
};

export default RecipeComponent;