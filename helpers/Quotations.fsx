// Copyright 2014 Jay Tuley <jay+code@tuley.name>
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

///Quotations Helpers
module FSharp.Interop.Compose.Quotations

///Convert a Quotation to a C# expression
let toExpression<'TDel> (expr:Quotations.Expr) =
    let rec uncurryToDelagate delType vlist callexpr =
        match callexpr with
                | Quotations.Patterns.Lambda(v,c) -> uncurryToDelagate delType (vlist @ [v]) c
                | _______________________________ -> Quotations.Expr.NewDelegate(delType, vlist, callexpr)
    expr
        |> uncurryToDelagate typeof<'TDel> []
        |>  Linq.RuntimeHelpers.LeafExpressionConverter.QuotationToExpression
        :?> System.Linq.Expressions.Expression<'TDel>
