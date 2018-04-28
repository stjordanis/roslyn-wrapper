﻿namespace BrightSword.RoslynWrapper.Tests

open Xunit

open BrightSword.RoslynWrapper

module LocalDeclarationTests =
    [<Fact>]
    let ``typed local variable: uninitialized`` () =
        let s = ``typed var`` "string" "name" None
        let m = host_in_method "void" [s]
        let actual = to_class_members_code [m]
        let expected = @"namespace N
{
    using System;

    public class C
    {
        protected internal void Host()
        {
            string name;
        }
    }
}"
        are_equal expected actual

    [<Fact>]
    let ``typed local variable: initialized`` () =
        let e = ``:=`` <| literal "John"
        let s =  ``typed var`` "string" "name" <| Some e
        let m = host_in_method "void" [s]
        let actual = to_class_members_code [m]
        let expected = @"namespace N
{
    using System;

    public class C
    {
        protected internal void Host()
        {
            string name = ""John"";
        }
    }
}"
        are_equal expected actual

    [<Fact>]
    let ``untyped local variable: initialized`` () =
        let s = ``var`` "name" (``:=`` <| literal "John") 
        let m = host_in_method "void" [s]
        let actual = to_class_members_code [m]
        let expected = @"namespace N
{
    using System;

    public class C
    {
        protected internal void Host()
        {
            var name = ""John"";
        }
    }
}"
        are_equal expected actual
