﻿namespace BrightSword.RoslynWrapper.Tests

open NUnit.Framework

open BrightSword.RoslynWrapper

module ClassTests =
    [<Test>]
    let ``class: empty``() =
        let c =
            ``class`` "C" ``<<`` [] ``>>``
                ``:`` None ``,`` []
                [``public``]
                ``{``
                    []
                ``}``
        let actual = to_namespace_member_code c
        let expected = @"namespace N
{
    using System;

    public class C
    {
    }
}"
        are_equal expected actual

    [<Test>]
    let ``class: base class``() =
        let c =
            ``class`` "C" ``<<`` [] ``>>``
                ``:`` (Some "B") ``,`` []
                [``public``]
                ``{``
                    []
                ``}``
        let actual = to_namespace_member_code c
        let expected = @"namespace N
{
    using System;

    public class C : B
    {
    }
}"
        are_equal expected actual


    [<Test>]
    let ``class: generic``() =
        let c =
            ``class`` "C" ``<<`` [ "T" ] ``>>``
                ``:`` None ``,`` []
                [``public``]
                ``{``
                    []
                ``}``
        let actual = to_namespace_member_code c
        let expected = @"namespace N
{
    using System;

    public class C<T>
    {
    }
}"
        are_equal expected actual

    [<Test>]
    let ``class: generic 2``() =
        let c =
            ``class`` "C" ``<<`` [ "R"; "S" ] ``>>``
                ``:`` None ``,`` []
                [``public``]
                ``{``
                    []
                ``}``
        let actual = to_namespace_member_code c
        let expected = @"namespace N
{
    using System;

    public class C<R, S>
    {
    }
}"
        are_equal expected actual

    [<Test>]
    let ``class: interfaces``() =
        let c =
            ``class`` "C" ``<<`` [] ``>>``
                ``:`` None ``,`` [ "IEnumerable"; "ISerializable" ]
                [``public``]
                ``{``
                    []
                ``}``
        let actual = to_namespace_member_code c
        let expected = @"namespace N
{
    using System;

    public class C : IEnumerable, ISerializable
    {
    }
}"
        are_equal expected actual

    [<Test>]
    let ``class: base and interfaces``() =
        let c =
            ``class`` "C" ``<<`` [] ``>>``
                ``:`` (Some "B") ``,`` [ "IEnumerable"; "ISerializable" ]
                [``public``]
                ``{``
                    []
                ``}``
        let actual = to_namespace_member_code c
        let expected = @"namespace N
{
    using System;

    public class C : B, IEnumerable, ISerializable
    {
    }
}"
        are_equal expected actual

    [<Test>]
    let ``class: private``() =
        let c =
            ``class`` "C" ``<<`` [] ``>>``
                ``:`` None ``,`` []
                [``private``]
                ``{``
                    []
                ``}``
        let actual = to_namespace_member_code c
        let expected = @"namespace N
{
    using System;

    private class C
    {
    }
}"
        are_equal expected actual

    [<Test>]
    let ``class: static``() =
        let c =
            ``class`` "C" ``<<`` [] ``>>``
                ``:`` None ``,`` []
                [``static``]
                ``{``
                    []
                ``}``
        let actual = to_namespace_member_code c
        let expected = @"namespace N
{
    using System;

    static class C
    {
    }
}"
        are_equal expected actual

    [<Test>]
    let ``class: internal``() =
        let c =
            ``class`` "C" ``<<`` [] ``>>``
                ``:`` None ``,`` []
                [``internal``]
                ``{``
                    []
                ``}``
        let actual = to_namespace_member_code c
        let expected = @"namespace N
{
    using System;

    internal class C
    {
    }
}"
        are_equal expected actual
        
    [<Test>]
    let ``class: partial``() =
        let c =
            ``class`` "C" ``<<`` [] ``>>``
                ``:`` None ``,`` []
                [``partial``]
                ``{``
                    []
                ``}``
        let actual = to_namespace_member_code c
        let expected = @"namespace N
{
    using System;

    partial class C
    {
    }
}"
        are_equal expected actual

    [<Test>]
    let ``class: private static partial``() =
        let c =
            ``class`` "C" ``<<`` [] ``>>``
                ``:`` None ``,`` []
                [``private``; ``static``; ``partial``]
                ``{``
                    []
                ``}``
        let actual = to_namespace_member_code c
        let expected = @"namespace N
{
    using System;

    private static partial class C
    {
    }
}"
        are_equal expected actual

