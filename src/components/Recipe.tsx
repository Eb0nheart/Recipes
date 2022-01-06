import * as React from "react";
import { Recipe } from "src/store/Recipe";

interface Props{
    recipe: Recipe
}

const RecipeComponent = (prop: Props) => {
    return (
        <div className="display-inline-flex">
            <h3 className="col-1">{prop.recipe.title}</h3>
            <p className="col">{prop.recipe.description}</p>
        </div>
    );
};

export default RecipeComponent;