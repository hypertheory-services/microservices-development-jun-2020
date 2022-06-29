/* eslint-disable */
import * as _m0 from "protobufjs/minimal";

export const protobufPackage = "";

export interface Course {
  id: string;
  body: Course_CourseInformation | undefined;
}

export interface Course_CourseInformation {
  id: string;
  description: string;
  category: string;
  numberOfDays: number;
}

function createBaseCourse(): Course {
  return { id: "", body: undefined };
}

export const Course = {
  encode(
    message: Course,
    writer: _m0.Writer = _m0.Writer.create()
  ): _m0.Writer {
    if (message.id !== "") {
      writer.uint32(10).string(message.id);
    }
    if (message.body !== undefined) {
      Course_CourseInformation.encode(
        message.body,
        writer.uint32(18).fork()
      ).ldelim();
    }
    return writer;
  },

  decode(input: _m0.Reader | Uint8Array, length?: number): Course {
    const reader = input instanceof _m0.Reader ? input : new _m0.Reader(input);
    let end = length === undefined ? reader.len : reader.pos + length;
    const message = createBaseCourse();
    while (reader.pos < end) {
      const tag = reader.uint32();
      switch (tag >>> 3) {
        case 1:
          message.id = reader.string();
          break;
        case 2:
          message.body = Course_CourseInformation.decode(
            reader,
            reader.uint32()
          );
          break;
        default:
          reader.skipType(tag & 7);
          break;
      }
    }
    return message;
  },

  fromJSON(object: any): Course {
    return {
      id: isSet(object.id) ? String(object.id) : "",
      body: isSet(object.body)
        ? Course_CourseInformation.fromJSON(object.body)
        : undefined,
    };
  },

  toJSON(message: Course): unknown {
    const obj: any = {};
    message.id !== undefined && (obj.id = message.id);
    message.body !== undefined &&
      (obj.body = message.body
        ? Course_CourseInformation.toJSON(message.body)
        : undefined);
    return obj;
  },

  fromPartial<I extends Exact<DeepPartial<Course>, I>>(object: I): Course {
    const message = createBaseCourse();
    message.id = object.id ?? "";
    message.body =
      object.body !== undefined && object.body !== null
        ? Course_CourseInformation.fromPartial(object.body)
        : undefined;
    return message;
  },
};

function createBaseCourse_CourseInformation(): Course_CourseInformation {
  return { id: "", description: "", category: "", numberOfDays: 0 };
}

export const Course_CourseInformation = {
  encode(
    message: Course_CourseInformation,
    writer: _m0.Writer = _m0.Writer.create()
  ): _m0.Writer {
    if (message.id !== "") {
      writer.uint32(10).string(message.id);
    }
    if (message.description !== "") {
      writer.uint32(18).string(message.description);
    }
    if (message.category !== "") {
      writer.uint32(26).string(message.category);
    }
    if (message.numberOfDays !== 0) {
      writer.uint32(32).int32(message.numberOfDays);
    }
    return writer;
  },

  decode(
    input: _m0.Reader | Uint8Array,
    length?: number
  ): Course_CourseInformation {
    const reader = input instanceof _m0.Reader ? input : new _m0.Reader(input);
    let end = length === undefined ? reader.len : reader.pos + length;
    const message = createBaseCourse_CourseInformation();
    while (reader.pos < end) {
      const tag = reader.uint32();
      switch (tag >>> 3) {
        case 1:
          message.id = reader.string();
          break;
        case 2:
          message.description = reader.string();
          break;
        case 3:
          message.category = reader.string();
          break;
        case 4:
          message.numberOfDays = reader.int32();
          break;
        default:
          reader.skipType(tag & 7);
          break;
      }
    }
    return message;
  },

  fromJSON(object: any): Course_CourseInformation {
    return {
      id: isSet(object.id) ? String(object.id) : "",
      description: isSet(object.description) ? String(object.description) : "",
      category: isSet(object.category) ? String(object.category) : "",
      numberOfDays: isSet(object.numberOfDays)
        ? Number(object.numberOfDays)
        : 0,
    };
  },

  toJSON(message: Course_CourseInformation): unknown {
    const obj: any = {};
    message.id !== undefined && (obj.id = message.id);
    message.description !== undefined &&
      (obj.description = message.description);
    message.category !== undefined && (obj.category = message.category);
    message.numberOfDays !== undefined &&
      (obj.numberOfDays = Math.round(message.numberOfDays));
    return obj;
  },

  fromPartial<I extends Exact<DeepPartial<Course_CourseInformation>, I>>(
    object: I
  ): Course_CourseInformation {
    const message = createBaseCourse_CourseInformation();
    message.id = object.id ?? "";
    message.description = object.description ?? "";
    message.category = object.category ?? "";
    message.numberOfDays = object.numberOfDays ?? 0;
    return message;
  },
};

type Builtin =
  | Date
  | Function
  | Uint8Array
  | string
  | number
  | boolean
  | undefined;

export type DeepPartial<T> = T extends Builtin
  ? T
  : T extends Array<infer U>
  ? Array<DeepPartial<U>>
  : T extends ReadonlyArray<infer U>
  ? ReadonlyArray<DeepPartial<U>>
  : T extends {}
  ? { [K in keyof T]?: DeepPartial<T[K]> }
  : Partial<T>;

type KeysOfUnion<T> = T extends T ? keyof T : never;
export type Exact<P, I extends P> = P extends Builtin
  ? P
  : P & { [K in keyof P]: Exact<P[K], I[K]> } & Record<
        Exclude<keyof I, KeysOfUnion<P>>,
        never
      >;

function isSet(value: any): boolean {
  return value !== null && value !== undefined;
}
